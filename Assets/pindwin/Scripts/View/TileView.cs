using UnityEngine;
using UnityEngine.EventSystems;

namespace pindwin.Scripts.View
{
	public class TileView : MonoBehaviour, IPointerClickHandler, IPointerDownHandler
	{
		public void OnPointerClick(PointerEventData eventData)
		{
			Debug.Log(gameObject.name);
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			Debug.Log(gameObject.name);
		}
	}
}