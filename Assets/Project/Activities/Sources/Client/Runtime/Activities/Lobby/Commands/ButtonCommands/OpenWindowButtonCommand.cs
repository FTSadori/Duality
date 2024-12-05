using UnityEngine;
using Client.Runtime.Framework.Unity;

namespace Client.Runtime.Activities.Lobby.Commands.ButtonCommands
{
    public sealed class OpenWindowButtonCommand : ButtonCommand
    {
        [SerializeField] GameObject _toOpen;

        public override void Execute()
        {
            _toOpen.SetActive(true);
        }
    }
}
