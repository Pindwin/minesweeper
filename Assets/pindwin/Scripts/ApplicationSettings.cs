using UnityEngine;

namespace pindwin.Scripts
{
	[CreateAssetMenu(menuName = "pindwin/ApplicationSettings", fileName = nameof(ApplicationSettings))]
	public class ApplicationSettings : ScriptableObject
	{
		[SerializeField] private Vector2Int _maxBoardSize;
		
		[HideInInspector] public Vector2Int BoardSize;
		[HideInInspector] public int Mines;

		public Vector2Int MaxBoardSize => _maxBoardSize;
	}
}