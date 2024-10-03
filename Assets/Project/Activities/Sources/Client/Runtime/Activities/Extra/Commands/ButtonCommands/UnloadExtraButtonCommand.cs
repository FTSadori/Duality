using Client.Runtime.Framework.Unity.SceneCommands;
using Client.Runtime.System;
using System.Collections.Generic;

namespace Client.Runtime.Activities.Extra.Commands.ButtonCommands
{
    public sealed class UnloadExtraButtonCommand : ManageScenesButtonCommand
    {
        protected override string SceneToLoadAndActivate => "";
        protected override List<string> ScenesToUnload => new() { Scenes.Activity.Extra };
        protected override List<string> ScenesToLoad => new() { Scenes.Activity.Lobby };
    }
}
