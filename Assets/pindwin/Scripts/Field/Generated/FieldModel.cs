// <auto-generated>
//	 This code was generated by a tool.
//
//	 Changes to this file may cause incorrect behavior and will be lost if
//	 the code is regenerated.
// </auto-generated>

using pindwin.umvr.Model;
using System.Collections.Generic;
using UniRx;

// ReSharper disable once CheckNamespace
namespace pindwin.Scripts.Field
{
	public partial class FieldModel : Model<FieldModel>, IField
	{
		private SingleProperty<pindwin.Scripts.Field.FieldState> _state;
		public pindwin.Scripts.Field.FieldState State
		{
			get => _state.Value;
			set
			{
				_state.Value = value;
			}
		}

		private SingleProperty<System.Boolean> _hasBomb;
		public System.Boolean HasBomb
		{
			get => _hasBomb.Value;
			set
			{
				_hasBomb.Value = value;
			}
		}

		private SingleProperty<System.Int32> _bombsNearby;
		public System.Int32 BombsNearby
		{
			get => _bombsNearby.Value;
			set
			{
				_bombsNearby.Value = value;
			}
		}

		private SingleProperty<System.Boolean> _isFailed;
		public System.Boolean IsFailed
		{
			get => _isFailed.Value;
			set
			{
				_isFailed.Value = value;
			}
		}

		public UnityEngine.Vector3Int Coordinates
		{
			get; private set;
		}


		public FieldModel(pindwin.umvr.Model.Id id, UnityEngine.Vector3Int coordinates) : base(id)
		{
			_state = new SingleProperty<pindwin.Scripts.Field.FieldState>(nameof(State));
			State = default;

			_hasBomb = new SingleProperty<System.Boolean>(nameof(HasBomb));
			HasBomb = default;

			_bombsNearby = new SingleProperty<System.Int32>(nameof(BombsNearby));
			BombsNearby = default;

			_isFailed = new SingleProperty<System.Boolean>(nameof(IsFailed));
			IsFailed = default;

			Coordinates = coordinates;

			RegisterDataStreams(this);
		}
	}
}