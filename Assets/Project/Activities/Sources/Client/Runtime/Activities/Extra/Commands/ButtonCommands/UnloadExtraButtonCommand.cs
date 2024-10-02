using Client.Runtime.Framework.Unity.SceneCommands;
using Client.Runtime.System;
using System.Collections.Generic;

namespace Client.Runtime.Activities.Extra.Commands.ButtonCommands
{
    public sealed class UnloadExtraButtonCommand : ChangeSceneButtonCommand
    {
        protected override string SceneToActivate => Scenes.Activity.Lobby;
        protected override List<string> ScenesToUnload => new() { Scenes.Activity.Extra };
    }
}
