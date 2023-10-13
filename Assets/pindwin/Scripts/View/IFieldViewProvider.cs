using UnityEngine;

namespace pindwin.Scripts.View
{
	public interface IFieldViewProvider
	{
		FieldView GetFieldView(Vector2Int coordinates);
	}
}