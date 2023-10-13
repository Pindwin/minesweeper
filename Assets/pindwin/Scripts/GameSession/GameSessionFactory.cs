using System;
using pindwin.development;
using pindwin.Scripts.Field;
using pindwin.Scripts.Topology;
using pindwin.umvr.Repository;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace pindwin.Scripts.GameSession
{
	public partial class GameSessionFactory
	{
		private readonly FieldFactory _fieldFactory;
		private readonly FieldRepository _fieldRepository;
		private readonly IMinefieldTopology _minefieldTopology;

		[Inject]
		public GameSessionFactory(
			IRepository<IGameSession> repository,
			FieldFactory fieldFactory,
			FieldRepository fieldRepository,
			IMinefieldTopology minefieldTopology)
			: this(repository, serializer: null)
		{
			_fieldFactory = fieldFactory.AssertNotNull();
			_fieldRepository = fieldRepository.AssertNotNull();
			_minefieldTopology = minefieldTopology.AssertNotNull();
		}

		public IGameSession Create(Vector3Int boardSize, int bombs)
		{
			if (boardSize.x * boardSize.y <= bombs)
			{
				throw new ArgumentException($"Board sized {boardSize} will not fit {bombs} bombs.");
			}

			IGameSession session = base.Create(boardSize);
			for (int x = 0; x < boardSize.x; x++)
			{
				for (int y = 0; y < boardSize.y; y++)
				{
					session.Fields.Add(_fieldFactory.Create(new Vector3Int(x, y, 0)));
				}
			}

			for (int i = 0; i < bombs; i++)
			{
				IField field;
				do
				{
					int x = Random.Range(0, boardSize.x);
					int y = Random.Range(0, boardSize.y);
					field = _fieldRepository.GetBy(nameof(IField.Coordinates), new Vector3Int(x, y, 0));
				}
				while (field == null || field.HasBomb == true);

				field.HasBomb = true;
			}
			
			for (int x = 0; x < boardSize.x; x++)
			{
				for (int y = 0; y < boardSize.y; y++)
				{
					IField field = _fieldRepository.GetBy(nameof(IField.Coordinates), new Vector3Int(x, y, 0));
					if (field.HasBomb)
					{
						continue;
					}
					field.BombsNearby = _minefieldTopology.GetBombsNearby(field);
				}
			}

			return session;
		}
	}
}