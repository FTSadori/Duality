using Client.Runtime.Framework.Unity;
using UnityEngine;

namespace Client.Runtime.Activities.Lobby.Commands.ButtonCommands
{
    public sealed class CloseWindowButtonCommand : ButtonCommand
    {
        [SerializeField] GameObject _toClose;

        public override void Execute()
        {
            _toClose.SetActive(false);
        }
    }
}
