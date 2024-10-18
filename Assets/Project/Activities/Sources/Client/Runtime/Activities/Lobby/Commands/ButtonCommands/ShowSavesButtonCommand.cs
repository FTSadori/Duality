using Client.Runtime.System;
using Client.Runtime.Framework.Unity.SceneCommands;
using System.Collections.Generic;

namespace Client.Runtime.Activities.Lobby.Commands.ButtonCommands
{
    public sealed class ShowSavesButtonCommand : ManageScenesButtonCommand
    {
        protected override string SceneToLoadAndActivate => "";
        protected override List<string> ScenesToUnload => new() { Scenes.Activity.Lobby };
        protected override List<string> ScenesToLoad => new() { Scenes.Activity.Saves };
    }
}
