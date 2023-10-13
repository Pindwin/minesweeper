using pindwin.development;
using pindwin.Scripts.GameSession.Generated;
using pindwin.Scripts.View;
using UnityEngine;
using Zenject;

namespace pindwin.Scripts.GameSession
{
	public partial class GameSessionReactor
	{
		private readonly BoardView _boardView;

		[Inject]
		public GameSessionReactor(GameSessionModel model, BoardView boardView) : this(model)
		{
			_boardView = boardView.AssertNotNull();
		}
		
		protected override void BindDataSourceImpl(GameSessionModel model)
		{
			_boardView.SetBoardSize(new Vector2Int(model.BoardSize.x, model.BoardSize.y));
		}
	}
}