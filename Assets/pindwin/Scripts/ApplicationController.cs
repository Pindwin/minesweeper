using pindwin.development;
using pindwin.Scripts.Commands;
using pindwin.Scripts.GameSession;
using UnityEngine;
using Zenject;

namespace pindwin.Scripts
{
	public sealed class ApplicationController : IInitializable
	{
		private GameSessionFactory _gameSessionFactory;
		
		[Inject]
		private void Inject(GameSessionFactory gameSessionFactory)
		{
			_gameSessionFactory = gameSessionFactory.AssertNotNull();
		}
		
		public void Initialize()
		{
			_gameSessionFactory.Create(new Vector3Int(8, 8, 0), 10);
		}
	}
}