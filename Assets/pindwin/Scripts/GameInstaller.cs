using pindwin.development;
using pindwin.Scripts;
using pindwin.Scripts.Commands;
using pindwin.Scripts.Field.Generated;
using pindwin.Scripts.GameSession.Generated;
using pindwin.Scripts.View;
using pindwin.umvr.Command;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private BoardView _board;
    
    public override void InstallBindings()
    {
        GameSessionInstallerBase.Install(Container);
        FieldInstallerBase.Install(Container);

        Container.Bind<UncoverFieldCommand>().AsSingle();

        Container.BindInterfacesAndSelfTo<BoardView>().FromInstance(_board).AsSingle();
        Container.BindInterfacesAndSelfTo<UnityLogger>().AsSingle();
        Container.BindInterfacesAndSelfTo<ApplicationController>().AsSingle();

        Container.Bind<ICommand<Vector3Int>>().To<UncoverFieldCommand>().FromResolve().WhenInjectedInto<FieldView>();

        Container.Bind<ZenjectToken>().AsSingle();
    }
}