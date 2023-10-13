using pindwin.development;
using pindwin.Scripts.Commands;
using pindwin.Scripts.GameSession;
using UnityEngine;
using Zenject;

namespace pindwin.Scripts
{
	public sealed class GameController : IInitializable
	{
		private readonly GameSessionFactory _gameSessionFactory;
		private readonly ApplicationSettings _applicationSettings;
		
		private GameController(GameSessionFactory gameSessionFactory, ApplicationSettings applicationSettings)
		{
			_gameSessionFactory = gameSessionFactory.AssertNotNull();
			_applicationSettings = applicationSettings.AssertNotNull();
		}
		
		public void Initialize()
		{
			Vector2Int size = _applicationSettings.BoardSize;
			_gameSessionFactory.Create(new Vector3Int(size.x, size.y, 0), _applicationSettings.Mines);
		}
	}
}