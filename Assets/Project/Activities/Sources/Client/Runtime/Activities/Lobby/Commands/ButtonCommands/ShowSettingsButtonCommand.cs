using Client.Runtime.Framework.Unity.SceneCommands;
using Client.Runtime.System;
using System.Collections.Generic;

namespace Client.Runtime.Activities.Lobby.Commands.ButtonCommands
{
    public sealed class ShowSettingsButtonCommand : ChangeSceneButtonCommand
    {
        protected override string SceneToActivate => Scenes.Activity.Settings;
        protected override List<string> ScenesToUnload => new() { Scenes.Activity.Lobby };
    }
}
