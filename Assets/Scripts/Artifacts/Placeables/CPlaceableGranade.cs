using UnityEngine;

namespace VEngine.Game.Items.Granade
{
	public class CPlaceableGranade 
		//: ThrowableBehaviour
	{
		//[SerializeField] private GameObject _placedPart;
		//[SerializeField] private GameObject _targetingPart;
		//[SerializeField] private Renderer _targetingPartRenderer;
		//[SerializeField] private LayerMask _placeableLayer;
		//[SerializeField] private Color _goodTargeting;
		//[SerializeField] private Color _badTargeting;

		//private bool _isGood = false;
		
		//public bool IsGood
		//{
		//	get => _isGood;
		//	set
		//	{
		//		_isGood = value;
		//		_targetingPartRenderer.material.SetColor("_BaseColor", value ? _goodTargeting : _badTargeting);
		//	}
		//}

		//public void PutHand(bool active) => _targetingPart.SetActive(active);

		//public override bool Use(Vector3 from, Vector3 dir, float force)
		//{
		//	if (!_isGood)
		//		return false;
		//	Placed(true);
		//	return true;
		//}

		//public override void Targeting(Vector3 from, Vector3 dir, float maxDistance)
		//{
		//	if (!Physics.Raycast(from, dir, out var hit, maxDistance, _placeableLayer))
		//	{
		//		IsGood = false;
		//		SetPositionAndRotation(from + dir * maxDistance, -dir, Color.red);
		//		return;
		//	}
		//	IsGood = true;
		//	SetPositionAndRotation(hit.point, hit.normal, Color.green);
		//}

		//private void SetPositionAndRotation(Vector3 position, Vector3 normal, Color color)
		//{
		//	transform.position = position;
		//	transform.forward = normal;
		//	Debug.DrawRay(position, normal, color, 5.0f);
		//}

		//public override void StartTargeting()
		//{
		//	Placed(false);
		//}

		//private void Placed(bool targeting)
		//{
		//	_placedPart.SetActive(targeting);
		//	_targetingPart.SetActive(!targeting);
		//	Invoke(nameof(Detonate), 3.0f);
		//}

		//public override void Detonate()
		//{
		//	base.Detonate();
		//	_placedPart.SetActive(false);
		//}
	}
}
