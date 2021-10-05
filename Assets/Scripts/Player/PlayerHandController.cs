using UnityEngine;

namespace VEngine.Player
{
	public enum eHandItemType
	{
		None,
		StunGranade,
		C4,
		Bottle
	}

	public class PlayerHandController : MonoBehaviour
	{
		//[SerializeField] private CGranadeController _granadeController;
		//[SerializeField] private Transform _handAnchor;

		//private eHandItemType _activeItem = eHandItemType.None;

		//public Vector3 ViewForward { get => _handAnchor.forward; }
		//public Vector3 StartPosition {get => _handAnchor.position; }

		//public eHandItemType ActiveItem 
		//{ 
		//	get => _activeItem; 
		//	private set
		//	{
		//		_activeItem = value;
		//		if(IsGranade(_activeItem, out var granadeType))
		//		{
		//			_granadeController.StartTargeting(granadeType);
		//		}
		//		else
		//		{
		//			_granadeController.StopTargeting();
		//		}
		//	}
		//}

		//public void Init()
		//{
		//	//TODO SO & ASSEMBPLY
		//	//_granadeController.Init(this);
		//}

		//private bool IsGranade(eHandItemType activeItem, out eGranadeType granadeType)
		//{
		//	switch (activeItem)
		//	{
		//		case eHandItemType.StunGranade:
		//			granadeType = eGranadeType.Stun;
		//			return true;
		//		case eHandItemType.C4:
		//			granadeType = eGranadeType.C4;
		//			return true;
		//		case eHandItemType.Bottle:
		//			granadeType = eGranadeType.Bottle;
		//			return true;
		//	}
		//	granadeType = eGranadeType.None;
		//	return false;
		//}

		//public void TakeInHand(eHandItemType item)
		//{
		//	ActiveItem = item;
		//}

		//public void Use()
		//{
		//	//TODO SO & ASSEMBPLY
		//	//if (ActiveItem == eHandItemType.None)
		//	//	return;
		//	//if(!IsGranade(ActiveItem, out var granadeType) || !_granadeController.Use())
		//	//{
		//	//	return;
		//	//}
		//	//ActiveItem = eHandItemType.None;
		//}

		//private void TakeOut()
		//{

		//}

		//private void PutAway()
		//{

		//}
	}
}
