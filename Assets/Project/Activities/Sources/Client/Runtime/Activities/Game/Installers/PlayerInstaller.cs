using Client.Runtime.Activities.Game.Player;
using Zenject;

namespace Client.Runtime.Activities.Game.Installers
{
    public sealed class PlayerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<PlayerModel>()
                .AsSingle();
        }
    }
}
