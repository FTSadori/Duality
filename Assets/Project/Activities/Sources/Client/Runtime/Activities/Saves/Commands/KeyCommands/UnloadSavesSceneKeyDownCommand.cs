using Client.Runtime.Activities.Saves.Commands.ButtonCommands;
using Client.Runtime.Framework.Unity;
using UnityEngine;

namespace Client.Runtime.Activities.Saves.Commands.KeyCommands
{
    public sealed class UnloadSavesSceneKeyDownCommand : KeyDownCommand
    {
        [SerializeField] private GameObject _alternativeCommandObject;

        public override void Execute()
        {
            _alternativeCommandObject.GetComponent<UnloadSavesSceneButtonCommand>().Execute();
        }
    }
}
