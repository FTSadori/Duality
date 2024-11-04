using Client.Runtime.Framework.Unity;
using UnityEngine;

namespace Client.Runtime.Activities.ExitGamePopUp.Commands.ButtonCommands
{
    public sealed class AgreeExitButtonCommand : ButtonCommand
    {
        public override void Execute()
        {
            Application.Quit();
        }
    }
}
