using UnityEngine;

namespace pindwin.Scripts.View
{
	public class BoardView : MonoBehaviour, IFieldViewProvider
	{
		[SerializeField] private FieldRowView[] _tileRows;
		
		public FieldView GetFieldView(Vector2Int coordinates)
		{
			return _tileRows[coordinates.y].Tiles[coordinates.x];
		}
	}
}