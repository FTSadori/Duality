using Client.Runtime.System;
using Client.Runtime.Framework.Unity.SceneCommands;
using System.Collections.Generic;

namespace Client.Runtime.Activities.Lobby.Commands.ButtonCommands
{
    public sealed class ShowSavesButtonCommand : ChangeSceneButtonCommand
    {
        protected override string SceneToActivate => Scenes.Activity.Saves;
        protected override List<string> ScenesToUnload => new() { Scenes.Activity.Lobby };
    }
}
