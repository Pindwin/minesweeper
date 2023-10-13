using System.Collections.Generic;
using pindwin.Scripts.Field;
using pindwin.umvr.Attributes;
using pindwin.umvr.Model;
using UnityEngine;

namespace pindwin.Scripts.GameSession
{
	[Singleton]
	public interface IGameSession : IModel
	{
		Vector3Int BoardSize { get; }
		int BombsCount { get; }
		bool IsGameLost { get; set; }
		IList<IField> Fields { get; set; }
	}
}