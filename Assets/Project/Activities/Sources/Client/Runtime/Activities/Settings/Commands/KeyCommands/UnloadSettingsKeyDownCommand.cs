using Client.Runtime.Activities.Settings.Commands.ButtonCommands;
using Client.Runtime.Framework.Unity;
using UnityEngine;

namespace Client.Runtime.Activities.Settings.Commands.KeyCommands
{
    public sealed class UnloadSettingsKeyDownCommand : KeyDownCommand
    {
        [SerializeField] private GameObject _alternativeCommandObject;

        public override void Execute()
        {
            _alternativeCommandObject.GetComponent<UnloadSettingsButtonCommand>().Execute();
        }
    }
}
