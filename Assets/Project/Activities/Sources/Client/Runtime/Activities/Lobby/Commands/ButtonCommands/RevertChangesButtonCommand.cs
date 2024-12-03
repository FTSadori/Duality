using Client.Runtime.Activities.Lobby.Commands.ButtonCommands.Playfab;
using Client.Runtime.Framework.Unity;
using UnityEngine;

namespace Runtime.Activities.Lobby.Commands.ButtonCommands
{
    public sealed class RevertChangesButtonCommand : ButtonCommand
    {
        [SerializeField] ProfilePlayfabGetter _playfabGetter;

        public override void Execute()
        {
            _playfabGetter.Execute();
        }
    }
}
