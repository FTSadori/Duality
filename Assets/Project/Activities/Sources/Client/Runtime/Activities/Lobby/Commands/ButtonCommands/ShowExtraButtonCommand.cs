using Client.Runtime.Framework.Unity.SceneCommands;
using Client.Runtime.System;
using System.Collections.Generic;

namespace Client.Runtime.Activities.Lobby.Commands.ButtonCommands
{
    public sealed class ShowExtraButtonCommand : ManageScenesButtonCommand
    {
        protected override string SceneToLoadAndActivate => "";
        protected override List<string> ScenesToUnload => new() { Scenes.Activity.Lobby };
        protected override List<string> ScenesToLoad => new() { Scenes.Activity.Extra };
    }
}
