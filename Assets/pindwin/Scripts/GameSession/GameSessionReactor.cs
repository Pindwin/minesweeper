using pindwin.development;
using pindwin.Scripts.Field;
using pindwin.Scripts.View;
using UniRx;
using UnityEngine;
using Zenject;

namespace pindwin.Scripts.GameSession
{
	public partial class GameSessionReactor
	{
		private readonly GameSessionModel _model;
		private readonly BoardView _boardView;

		[Inject]
		public GameSessionReactor(GameSessionModel model, BoardView boardView) : this(model)
		{
			_model = model;
			_boardView = boardView.AssertNotNull();
		}
		
		protected override void BindDataSourceImpl(GameSessionModel model)
		{
			_boardView.SetBoardSize(new Vector2Int(model.BoardSize.x, model.BoardSize.y));
			_boardView.gameObject.SetActive(true);

			model
				.GetProperty<bool>(nameof(IGameSession.IsGameLost))
				.Where(b => b)
				.Subscribe(LoseGame)
				.AddTo(Subscriptions);
		}

		private void LoseGame(bool isLost)
		{
			for (int i = 0; i < _model.Fields.Count; i++)
			{
				IField field = _model.Fields[i];
				if (field.HasBomb)
				{
					field.State = FieldState.Exposed;
					field.IsFailed = true;
				}
			}
		}
	}
}