using pindwin.development;
using pindwin.Scripts.Field;
using pindwin.umvr.Command;
using UnityEngine;

namespace pindwin.Scripts.Commands
{
	public class UncoverFieldCommand : ConditionalCommand<Vector3Int>
	{
		private readonly FieldRepository _fieldRepository;

		public UncoverFieldCommand(FieldRepository fieldRepository)
		{
			_fieldRepository = fieldRepository.AssertNotNull();
		}
		
		public override bool CanExecute()
		{
			return true;
		}

		protected override void ExecuteImpl(Vector3Int param)
		{
			_fieldRepository.GetBy(nameof(IField.Coordinates), param).State = FieldState.Exposed;
		}

		public override bool IsValid(Vector3Int payload)
		{
			IField field = _fieldRepository.GetBy(nameof(IField.Coordinates), payload);
			return field != null && field.State == FieldState.Hidden;
		}
	}
}