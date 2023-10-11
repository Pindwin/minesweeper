using pindwin.development;
using Zenject;

namespace pindwin.Scripts
{
	public sealed class ApplicationController : IInitializable
	{
		private ILogger _logger;
		
		[Inject]
		private void Inject(ILogger logger)
		{
			_logger = logger.AssertNotNull();
		}
		
		public void Initialize()
		{
			_logger.Log("Hello World!");
		}
	}
}