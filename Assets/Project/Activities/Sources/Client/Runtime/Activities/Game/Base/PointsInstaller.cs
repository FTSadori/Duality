using Client.Runtime.Activities.Game.Installers;
using Zenject;

namespace Client.Runtime.Activities.Game.Base
{
    public sealed class PointsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<PointsModel>()
                .AsSingle();
        }
    }
}
