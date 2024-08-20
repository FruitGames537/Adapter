using UnityEngine.EventSystems;

namespace Adapter.Styles
{
	public interface IStyle<T> where T : UIBehaviour
	{
		public void Apply(T element);
	}
}