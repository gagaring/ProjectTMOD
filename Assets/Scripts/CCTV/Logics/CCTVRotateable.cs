using VEngine.Enviroment.Rotate;
using VEngine.SO.Events;

namespace VEngine.CCTV
{
	public class CCTVRotateable : ICCTVRotateable
	{
		private readonly IData _data;
		private readonly IComponents _components;

		public virtual bool CanRotatePositive => _components.RotateBetweenFixes.CanRotatePositive;
		public virtual bool CanRotateNegative => _components.RotateBetweenFixes.CanRotateNegative;

		public CCTVRotateable(IData data, IComponents components)
		{
			_data = data;
			_components = components;
			_components.Selectable.OnSelected += OnSelected;
		}

		private void OnSelected()
		{
			_data.OnRotateableSelectedEvent.Raise(this);
		}

		public virtual void Rotate(bool positivDir)
		{
			_components.RotateBetweenFixes.Rotate(positivDir);
		}

		public interface IData
		{
			IGameEvent<ICCTVRotateable> OnRotateableSelectedEvent { get; }
		}

		public interface IComponents
		{
			ICCTVSelectable Selectable { get; }
			IRotateBetweenFixes RotateBetweenFixes { get; }
		}
	}
}
