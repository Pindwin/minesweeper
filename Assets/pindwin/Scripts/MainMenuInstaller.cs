using pindwin.Scripts.Commands;
using UnityEngine;
using Zenject;

namespace pindwin.Scripts
{
	public class MainMenuInstaller : MonoInstaller
	{
		[SerializeField] private ApplicationSettings _settings;

		public override void InstallBindings()
		{
			Container.Bind<ApplicationSettings>().FromInstance(_settings);
			Container.Bind<SwitchSceneCommand>().AsSingle();
		}
	}
}