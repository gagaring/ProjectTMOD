using UnityEngine;
using System.Collections.Generic;

namespace VEngine.Game.Entity.Light
{
	public class CFlashlight_SightTargeted : MonoBehaviour
	{
		//[SerializeField] private UnityEngine.Light _light;
		//[SerializeField] private LayerMask _lightLayer;
		//[SerializeField] private float _energyDropPercentPerSec = 0.33333f;
		//[Header("FollowTarget")]
		//[SerializeField] private Transform _positionTarget;
		//[SerializeField] private Transform _rotateTarget;
		//[Header("TargetColliders")]
		//[SerializeField] private CSightTarget_Flashlight _sightTargetPrefab;
		//[SerializeField] private SingleUnityLayer _targetBoundLayer;
		//[SerializeField] private Transform _targetColliderHolder;
		//[SerializeField] [Range(1, 8)] private int _targetColliderCount;
		//[SerializeField] [Range(1, 100)] private int _raycastPerTargetCollider;
		//[SerializeField] private float _targetColliderUpdateFreq = 0.05f;

		//public float _energy = 100.0f;
		//private bool _isActive = false;
		//private float _nextTargetColliderUpdateTime;

		//private List<CFlashlightTargetBound> _targetBoxes = new List<CFlashlightTargetBound>();
		//private List<CSightTarget_Flashlight> _sightTargets = new List<CSightTarget_Flashlight>();

		//private void Awake()
		//{
		//	CreateTargetColliderBoxes();
		//	CreateSightTargets();
		//}

		//private void CreateSightTargets()
		//{
		//	var parent = (new GameObject("Emitters")).transform;
		//	ResetTransform(parent, transform);
		//	var max = _targetBoxes.Count * _raycastPerTargetCollider;
		//	for (int i = 0; i < max; ++i)
		//	{
		//		var target = Instantiate(_sightTargetPrefab);
		//		ResetTransform(target.transform, parent);
		//		target.gameObject.SetActive(false);
		//		_sightTargets.Add(target);
		//	}
		//}

		//private void CreateTargetColliderBoxes()
		//{
		//	var zAngle = 90.0f / _targetColliderCount;
		//	for (int i = 0; i < _targetColliderCount; ++i)
		//	{
		//		CreateTargetColliderBox(i, zAngle);
		//	}
		//}

		//private void CreateTargetColliderBox(int i, float zAngle)
		//{
		//	var go = new GameObject("Target " + i);
		//	go.layer = _targetBoundLayer.Mask;
		//	var box = go.AddComponent<BoxCollider>();
		//	var target = new CFlashlightTargetBound(box, _light, zAngle * i);
		//	go.transform.SetParent(_targetColliderHolder);
		//	_targetBoxes.Add(target);
		//}

		//private void UpdateSightTargets()
		//{
		//	if (_nextTargetColliderUpdateTime > Time.time)
		//		return;
		//	_nextTargetColliderUpdateTime = Time.time + _targetColliderUpdateFreq;
		//	for (int i = 0; i < _targetBoxes.Count; ++i)
		//	{
		//		UpdateSightTargets(_targetBoxes[i], i);
		//	}
		//}

		//private void UpdateSightTargets(CFlashlightTargetBound targetBoxes, int index)
		//{
		//	var add = index * _raycastPerTargetCollider;
		//	for(int i = 0; i < _raycastPerTargetCollider; ++i)
		//	{
		//		var sightTarget = _sightTargets[add + i];
		//		if (sightTarget.IsLocked(_light))
		//		{
		//			sightTarget.StayInPosition();
		//			continue;
		//		}
		//		var pos = targetBoxes.RandInnerPoint;
		//		UpdateSightTargets(sightTarget, pos);
		//	}
		//}

		//private void UpdateSightTargets(CSightTarget_Flashlight target, Vector3 raycastTarget)
		//{
		//	var normal = (raycastTarget - _light.transform.position).normalized;
		//	var ray = new Ray(_light.transform.position, normal);
		//	if (!Physics.Raycast(ray, out var hit, _light.range, _lightLayer))
		//	{
		//		target.gameObject.SetActive(false);
		//		return;
		//	}
		//	target.gameObject.SetActive(true);
		//	target.Position = hit.point;
		//}

		//private void ResetTransform(Transform trans, Transform parent)
		//{
		//	trans.parent = parent;
		//	trans.position = parent.position;
		//	trans.forward = parent.forward;
		//}

		//public void Turn(bool turn)
		//{
		//	if (!_isActive && !CanTurnOn())
		//		return;
		//	_light.gameObject.SetActive(turn);
		//}

		//private bool CanTurnOn()
		//{
		//	return _energy > 0.0f;
		//}

		//private void Update()
		//{
		//	UpdateEnergy();
		//	UpdateSightTargets();
		//	FollowTarget();
		//}

		//private void UpdateEnergy()
		//{
		//	_energy -= _energyDropPercentPerSec * Time.deltaTime;
		//	if (_energy <= 0.0f)
		//		Turn(false);
		//}

		//private void FollowTarget()
		//{
		//	transform.position = _positionTarget.position;
		//	transform.LookAt(transform.position + _rotateTarget.forward);
		//}
	}
}
