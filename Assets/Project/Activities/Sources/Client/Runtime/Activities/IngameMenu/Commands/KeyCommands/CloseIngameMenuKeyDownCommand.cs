using Client.Runtime.Activities.IngameMenu.Commands.ButtonCommands;
using Client.Runtime.Framework.Unity;
using UnityEngine;

namespace Client.Runtime.Activities.IngameMenu.Commands.KeyCommands
{
    public sealed class CloseIngameMenuKeyDownCommand : KeyDownCommand
    {
        [SerializeField] private GameObject _alternativeCommandObject;

        public override void Execute()
        {
            _alternativeCommandObject.GetComponent<CloseIngameMenuButtonCommand>().Execute();
        }
    }
}
