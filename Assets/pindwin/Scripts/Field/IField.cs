using pindwin.umvr.Model;
using UnityEngine;

namespace pindwin.Scripts.Field
{
	public interface IField : IModel
	{
		FieldState State { get; set; }
		bool HasBomb { get; set; }
		int BombsNearby { get; set; }
		bool IsFailed { get; set; }
		Vector3Int Coordinates { get; }
	}
}