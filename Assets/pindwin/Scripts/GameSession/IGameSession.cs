using System.Collections.Generic;
using pindwin.Scripts.Field;
using pindwin.umvr.Attributes;
using pindwin.umvr.Model;

namespace pindwin.Scripts.GameSession
{
	[Singleton]
	public interface IGameSession : IModel
	{
		IList<IField> Fields { get; set; }
	}
}