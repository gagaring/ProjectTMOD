using UnityEngine;
using VEngine.AI.Senses.Sensors.Sight;
using VEngine.Anim;
using VEngine.Camera;
using VEngine;
using VEngine.SO.Variables;
using VEngine.Player;
using VEngine.Game.Move;

namespace VEngine.AI.Enemy.Teleporter
{
	public class Teleporter : MonoBehaviour
	{
		//TODO SO (CameraShake torolve fullra, CameraShakeDataReference kell ide!)
		[SerializeField] private TransformSO _playerTransform;
		[SerializeField] private Mover_NavMesh _moveController;

		[SerializeField] private Sight_OnlyPlayer _sight;
		[SerializeField] private LayerMask _playerLayer;
		[SerializeField] private LayerMask _enemyLayer;
		[SerializeField] private Collider _faceCollider;
		[SerializeField] private float _timeToKill = 2.0f;
		[SerializeField] private float _decreaseMultiplier = 0.5f;
		[SerializeField] private float _sqrKillDistance;
		[SerializeField] private float _maxCameraForwardAngleDiff = 15.0f;

		[SerializeField] private Teleporter_PostProccessing _postProccessing;
		[SerializeField] private TeleporterAnimatorController _animatorController;

		[Header("Sound")]
		[SerializeField] private AudioSource _teleportSound;
		[SerializeField] private AnimationCurve _shockVolumeCurve;
		[SerializeField] private EnemyBaseSoundController _baseSoundController;

		private Transform _camera;
		private float _shockTimer = 0;

		public int NavMeshAreaMask { get => _moveController.NavMeshAreaMask; }
		public bool IsPlayerSeenProp { get; private set; }

		#region init
		public void Init(Transform cameraAnchor)
		{
			_postProccessing.Init();
			_baseSoundController.Init();
			_camera = cameraAnchor;
			//TODO SO
			//_moveController.OnSpeedChanged += _animatorController.OnSpeedChanged;
			DoReset();
			//_moveController.Speed = _moveController.MaxSpeed;
		}

		private void OnDestroy()
		{
			//if(_moveController)
			//	_moveController.OnSpeedChanged -= _animatorController.OnSpeedChanged;
		}

		private void DoReset()
		{
			_shockTimer = 0.0f;
			_postProccessing.DoReset();
		}
		#endregion

		public void TeleportToPosition(Vector3 position)
		{
			_moveController.TeleportTo(position);
			OnTeleported();
		}

		public void Update()
		{
			_moveController.MovePosition(_playerTransform.Position);
			FacePlayer();
			UpdateShockTimer();
			if (_shockTimer >= _timeToKill)
			{
				KillPlayer();
				return;
			}
			ShockPlayer();
		}

		private void FacePlayer()
		{
			var playerPosition = _playerTransform.Position;
			var directon = (playerPosition - transform.position).normalized;
			playerPosition.y = transform.position.y;
			transform.LookAt(playerPosition);
		}

		private void UpdateShockTimer()
		{
			IsPlayerSeenProp = IsPlayerSeen();
			if (IsPlayerSeenProp && (IsPlayerSeeMe() || IsPlayerToClose()))
			{
				_shockTimer += Time.deltaTime;
			}
			else
			{
				_shockTimer -= Time.deltaTime * _decreaseMultiplier;
			}
			Utils.MinMax(ref _shockTimer, 0.0f, _timeToKill);
		}

		private bool IsPlayerToClose()
		{
			var sqrDistance = Vector3.SqrMagnitude(_playerTransform.Position - transform.position);
			return _sqrKillDistance >= sqrDistance;
		}

		private bool IsPlayerSeen()
		{
			if (_sight.Targets.Count == 0)
				return false;
			if (!Physics.Raycast(transform.position, _playerTransform.Position - transform.position, out var hitInfo, _sight.SightRange, _playerLayer))
				return false;
			var player = hitInfo.collider.GetComponentInParent<PlayerBehaviour>();
			return player != null;
		}

		private bool IsPlayerSeeMe()
		{
			var toFaceColliderDir = _faceCollider.transform.position - _camera.transform.position;
			toFaceColliderDir.Normalize();
			if (Vector3.Angle(_camera.forward, toFaceColliderDir) > _maxCameraForwardAngleDiff)
				return false;
			if (!Physics.Raycast(_camera.transform.position, _faceCollider.transform.position - _camera.transform.position, out var hitInfo, _sight.SightRange, _enemyLayer))
				return false;
			return hitInfo.collider == _faceCollider;
		}

		private void ShockPlayer()
		{
			var rate = _shockTimer / _timeToKill;
			_postProccessing.SetDyingRate(rate);
		}

		private void OnTeleported()
		{
			_teleportSound.Play();
		}

		private void KillPlayer()
		{
			//TODO
			//_player.TakeDamage(float.MaxValue);
		}
	}
}