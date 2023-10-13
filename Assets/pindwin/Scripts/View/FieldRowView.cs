using UnityEngine;

namespace pindwin.Scripts.View
{
	public class FieldRowView : MonoBehaviour
	{
		[SerializeField] private FieldView[] _tiles;

		public FieldView[] Tiles => _tiles;
	}
}