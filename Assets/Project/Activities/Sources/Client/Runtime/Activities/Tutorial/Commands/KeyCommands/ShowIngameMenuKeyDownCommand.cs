using Client.Runtime.Activities.Tutorial.Commands.ButtonCommands;
using Client.Runtime.Framework.Unity;
using UnityEngine;

namespace Client.Runtime.Activities.Tutorial.Commands.KeyCommands
{
    public sealed class ShowIngameMenuKeyDownCommand : KeyDownCommand
    {
        [SerializeField] private GameObject _alternativeCommandObject;

        public override void Execute()
        {
            _alternativeCommandObject.GetComponent<ShowIngameMenuButtonCommand>().Execute();
        }
    }
}
