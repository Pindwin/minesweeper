using pindwin.development;
using pindwin.Scripts.Field;
using UnityEngine;

namespace pindwin.Scripts.Topology
{
	public class SquareGridMinefieldTopology : IMinefieldTopology
	{
		private readonly ApplicationSettings _settings;
		private readonly FieldRepository _fieldRepository;

		public SquareGridMinefieldTopology(FieldRepository fieldRepository, ApplicationSettings settings)
		{
			_fieldRepository = fieldRepository.AssertNotNull();
			_settings = settings.AssertNotNull();
		}
		
		public int GetBombsNearby(IField field)
		{
			int xOriginal = field.Coordinates.x;
			int yOriginal = field.Coordinates.y;

			int result = 0;
			for (int x = xOriginal - 1; x <= xOriginal + 1; x++)
			{
				if (x < 0 || x > _settings.MaxBoardSize.x)
				{
					continue;
				}
				
				for (int y = yOriginal - 1; y <= yOriginal + 1; y++)
				{
					if (y < 0 || y > _settings.MaxBoardSize.y)
					{
						continue;
					}
					
					if (x == xOriginal && y == yOriginal)
					{
						continue;
					}

					if (_fieldRepository.GetBy(nameof(IField.Coordinates), new Vector3Int(x, y, 0))?.HasBomb == true)
					{
						result += 1;
					}
				}
			}

			return result;
		}
	}
}