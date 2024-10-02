
using Client.Runtime.Framework.Unity.SceneCommands;
using Client.Runtime.System;
using System.Collections.Generic;

namespace Client.Runtime.Activities.ExitGamePopUp.Commands.ButtonCommands
{
    public sealed class DisagreeExitButtonCommand : UnloadSceneButton
    {
        protected override List<string> ScenesToUnload => new() { Scenes.Activity.ExitGamePopUp };
    }
}
