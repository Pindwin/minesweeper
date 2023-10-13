using pindwin.development;
using pindwin.Scripts.GameSession;
using UnityEngine;
using Zenject;
using ILogger = pindwin.development.ILogger;

namespace pindwin.Scripts
{
	public sealed class ApplicationController : IInitializable
	{
		private ILogger _logger;
		private GameSessionFactory _gameSessionFactory;
		
		[Inject]
		private void Inject(ILogger logger, GameSessionFactory gameSessionFactory)
		{
			_logger = logger.AssertNotNull();
			_gameSessionFactory = gameSessionFactory.AssertNotNull();
		}
		
		public void Initialize()
		{
			_gameSessionFactory.Create(new Vector2Int(5, 5), 10);
		}
	}
}