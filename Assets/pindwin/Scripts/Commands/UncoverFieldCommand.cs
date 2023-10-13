using System.Collections.Generic;
using pindwin.development;
using pindwin.Scripts.Field;
using pindwin.Scripts.Topology;
using pindwin.umvr.Command;
using UnityEngine;

namespace pindwin.Scripts.Commands
{
	public class UncoverFieldCommand : ConditionalCommand<Vector3Int>
	{
		private readonly FieldRepository _fieldRepository;
		private readonly IMinefieldTopology _minefieldTopology;
		
		private readonly List<IField> _fieldsBuffer;
		private readonly List<IField> _fieldsToUncoverQueue;

		public UncoverFieldCommand(FieldRepository fieldRepository, IMinefieldTopology minefieldTopology)
		{
			_fieldRepository = fieldRepository.AssertNotNull();
			_minefieldTopology = minefieldTopology.AssertNotNull();
			
			_fieldsToUncoverQueue = new List<IField>();
			_fieldsBuffer = new List<IField>();
		}
		
		public override bool CanExecute()
		{
			return true;
		}

		protected override void ExecuteImpl(Vector3Int param)
		{
			IField field = _fieldRepository.GetBy(nameof(IField.Coordinates), param);
			if (field.HasBomb)
			{
				LoseGame(field);
				return;
			}
			
			UncoverRecursively(field);
		}

		public override bool IsValid(Vector3Int payload)
		{
			IField field = _fieldRepository.GetBy(nameof(IField.Coordinates), payload);
			return field != null && field.State == FieldState.Hidden;
		}

		private void UncoverRecursively(IField field)
		{
			field.State = FieldState.Exposed;
			_fieldsToUncoverQueue.Remove(field);
			if (field.BombsNearby == 0 && field.HasBomb == false)
			{
				_minefieldTopology.GetFieldNeighboursNonAlloc(field, _fieldsBuffer);
				for (int i = 0; i < _fieldsBuffer.Count; i++)
				{
					IField f = _fieldsBuffer[i];
					if (f.State == FieldState.Hidden && _fieldsToUncoverQueue.Contains(f) == false)
					{
						_fieldsToUncoverQueue.Add(f);
					}
				}
			}

			if (_fieldsToUncoverQueue.Count > 0)
			{
				UncoverRecursively(_fieldsToUncoverQueue[0]);
			}
		}

		private void LoseGame(IField field)
		{
			field.State = FieldState.Exposed;
			Debug.LogError("Game lost!");
		}
	}
}