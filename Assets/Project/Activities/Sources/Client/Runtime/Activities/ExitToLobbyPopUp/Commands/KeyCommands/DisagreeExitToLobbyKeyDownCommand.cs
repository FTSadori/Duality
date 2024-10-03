using Client.Runtime.Activities.ExitToLobbyPopUp.Commands.ButtonCommands;
using Client.Runtime.Framework.Unity;
using UnityEngine;

namespace Client.Runtime.Activities.ExitToLobbyPopUp.Commands.KeyCommands
{
    public sealed class DisagreeExitToLobbyKeyDownCommand : KeyDownCommand
    {
        [SerializeField] private GameObject _alternativeCommandObject;

        public override void Execute()
        {
            _alternativeCommandObject.GetComponent<DisagreeExitToLobbyButtonCommand>().Execute();
        }
    }
}
