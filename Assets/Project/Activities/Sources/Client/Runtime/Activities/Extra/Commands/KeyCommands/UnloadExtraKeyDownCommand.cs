using Client.Runtime.Activities.Extra.Commands.ButtonCommands;
using Client.Runtime.Framework.Unity;
using UnityEngine;

namespace Client.Runtime.Activities.Extra.Commands.KeyCommands
{
    public sealed class UnloadExtraKeyDownCommand : KeyDownCommand
    {
        [SerializeField] private GameObject _alternativeCommandObject;

        public override void Execute()
        {
            _alternativeCommandObject.GetComponent<UnloadExtraButtonCommand>().Execute();
        }
    }
}
