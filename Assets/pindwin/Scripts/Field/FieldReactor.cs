using pindwin.Scripts.View;
using UnityEngine;
using UniRx;
using Zenject;

namespace pindwin.Scripts.Field
{
	public partial class FieldReactor
	{
		private readonly FieldView _view;

		[Inject]
		public FieldReactor(FieldModel model, IFieldViewProvider fieldViewProvider) : this(model)
		{
			_view = fieldViewProvider.GetFieldView(new Vector2Int(model.Coordinates.x, model.Coordinates.y));
		}
		
		protected override void BindDataSourceImpl(FieldModel model)
		{
			_view.Payload = model.Coordinates;
			
			model
				.GetProperty<bool>(nameof(IField.HasBomb))
				.Subscribe(b =>
				{
					if (b)
					{
						_view.Text = "X";
					}
				})
				.AddTo(Subscriptions);
			model.GetProperty<int>(nameof(IField.BombsNearby)).Subscribe(bn => 
				{
					if (bn > 0)
					{
						_view.Text = bn.ToString();
					}
				})
				.AddTo(Subscriptions);
			model
				.GetProperty<FieldState>(nameof(IField.State))
				.Subscribe(fs => _view.IsHidden = fs == FieldState.Hidden)
				.AddTo(Subscriptions);
			model
				.GetProperty<bool>(nameof(IField.IsFailed))
				.Subscribe(f => _view.IsFailed = f)
				.AddTo(Subscriptions);
		}
	}
}