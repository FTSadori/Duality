using Client.Runtime.Activities.Lobby.Commands.ButtonCommands;
using Client.Runtime.Framework.Unity;
using UnityEngine;

namespace Client.Runtime.Activities.Lobby.Commands.KeyCommands
{
    public sealed class ExitGameKeyDownCommand : KeyDownCommand
    {
        [SerializeField] private GameObject _alternativeCommandObject;

        public override void Execute()
        {
            _alternativeCommandObject.GetComponent<ExitGameButtonCommand>().Execute();
        }
    }
}
