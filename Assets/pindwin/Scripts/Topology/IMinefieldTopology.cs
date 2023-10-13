using System.Collections.Generic;
using pindwin.Scripts.Field;

namespace pindwin.Scripts.Topology
{
	public interface IMinefieldTopology
	{
		int GetBombsNearby(IField field);
		void GetFieldNeighboursNonAlloc(IField field, List<IField> neighbours);
	}
}