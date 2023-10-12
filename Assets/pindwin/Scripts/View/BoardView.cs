using UnityEngine;

namespace pindwin.Scripts.View
{
	public class BoardView : MonoBehaviour
	{
		[SerializeField] private TileRowView[] _tileRows;

		public TileRowView[] TileRows => _tileRows;
	}
}