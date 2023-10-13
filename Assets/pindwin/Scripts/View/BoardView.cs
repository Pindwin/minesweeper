using UnityEngine;

namespace pindwin.Scripts.View
{
	public class BoardView : MonoBehaviour, IFieldViewProvider
	{
		[SerializeField] private FieldRowView[] _tileRows;

		public void SetBoardSize(Vector2Int boardSize)
		{
			for (int y = 0; y < _tileRows.Length; y++)
			{
				FieldRowView fieldRowView = _tileRows[y];
				fieldRowView.gameObject.SetActive(y < boardSize.y);
				for (int x = 0; x < fieldRowView.Tiles.Length; x++)
				{
					FieldView fieldView = fieldRowView.Tiles[x];
					bool isActive = x < boardSize.x;
					fieldView.gameObject.SetActive(isActive);
					if (isActive)
					{
						fieldView.Reset();
					}
				}
			}
		}
		
		public FieldView GetFieldView(Vector2Int coordinates)
		{
			return _tileRows[coordinates.y].Tiles[coordinates.x];
		}
	}
}