using UnityEngine;
using Zenject;

public class ZenjectInstaller : MonoInstaller<ZenjectInstaller>
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<InputManager>().AsSingle();
        Container.BindInterfacesAndSelfTo<ApplicationManager>().AsSingle();
    }
}