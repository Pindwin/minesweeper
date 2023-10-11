using pindwin.development;
using pindwin.Scripts;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<UnityLogger>().AsSingle();
        Container.BindInterfacesAndSelfTo<ApplicationController>().AsSingle();
    }
}