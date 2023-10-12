using UnityEngine;

namespace pindwin.Scripts.View
{
	public class TileRowView : MonoBehaviour
	{
		[SerializeField] private TileView[] _tiles;

		public TileView[] Tiles => _tiles;
	}
}