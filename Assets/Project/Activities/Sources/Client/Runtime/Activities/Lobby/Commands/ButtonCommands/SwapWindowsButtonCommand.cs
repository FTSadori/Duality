using Client.Runtime.Framework.Unity;
using UnityEngine;

namespace Client.Runtime.Activities.Lobby.Commands.ButtonCommands
{
    public sealed class SwapWindowsButtonCommand : ButtonCommand
    {
        [SerializeField] GameObject _toOpen;
        [SerializeField] GameObject _toClose;

        public override void Execute()
        {
            _toOpen.SetActive(true);
            _toClose.SetActive(false);
        }
    }
}
