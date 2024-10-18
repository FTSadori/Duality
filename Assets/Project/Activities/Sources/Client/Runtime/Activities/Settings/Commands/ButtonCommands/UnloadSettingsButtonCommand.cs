using Client.Runtime.Framework.Unity.SceneCommands;
using Client.Runtime.System;
using System.Collections.Generic;

namespace Client.Runtime.Activities.Settings.Commands.ButtonCommands
{
    public sealed class UnloadSettingsButtonCommand : ManageScenesButtonCommand
    {
        protected override string SceneToLoadAndActivate => "";
        protected override List<string> ScenesToUnload => new() { Scenes.Activity.Settings };
        protected override List<string> ScenesToLoad => new() { Scenes.Activity.Lobby };
    }
}
