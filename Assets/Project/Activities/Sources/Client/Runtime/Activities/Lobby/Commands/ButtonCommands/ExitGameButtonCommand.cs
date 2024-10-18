using Client.Runtime.Framework.Unity.SceneCommands;
using Client.Runtime.System;
using System.Collections.Generic;

namespace Client.Runtime.Activities.Lobby.Commands.ButtonCommands
{
    public sealed class ExitGameButtonCommand : LoadSceneButton
    {
        protected override string SceneToLoadAndActivate => "";
        protected override List<string> ScenesToLoad => new() { Scenes.Activity.ExitGamePopUp };
    }
}
