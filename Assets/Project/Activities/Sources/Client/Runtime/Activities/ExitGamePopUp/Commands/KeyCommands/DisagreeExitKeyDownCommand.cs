using Client.Runtime.Activities.ExitGamePopUp.Commands.ButtonCommands;
using Client.Runtime.Framework.Unity;
using UnityEngine;

namespace Client.Runtime.Activities.ExitGamePopUp.Commands.KeyCommands
{
    public sealed class DisagreeExitKeyDownCommand : KeyDownCommand
    {
        [SerializeField] private GameObject _alternativeCommandObject;

        public override void Execute()
        {
            _alternativeCommandObject.GetComponent<DisagreeExitButtonCommand>().Execute();
        }
    }
}
