using Zenject;

public class ZenjectInstaller : MonoInstaller<ZenjectInstaller>
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<InputManager>().AsSingle();
        Container.BindInterfacesAndSelfTo<ApplicationManager>().AsSingle();
        Container.Bind<IPoi>().FromComponentsInHierarchy(includeInactive: false).AsTransient();
    }
}