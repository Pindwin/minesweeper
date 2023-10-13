using pindwin.Scripts.Field;

namespace pindwin.Scripts.Topology
{
	public interface IMinefieldTopology
	{
		int GetBombsNearby(IField field);
	}
}