using Client.Runtime.Framework.Unity;

namespace Client.Runtime.Activities.Lobby.Base
{
    public abstract class PickItemButtonCommand : ButtonCommand
    {
        public abstract PriceLabelController PriceLabelController { get; }

        public abstract void Unblock();
    }
}
