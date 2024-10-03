using Client.Runtime.System;
using Client.Runtime.Framework.Unity.SceneCommands;
using System.Collections.Generic;

namespace Client.Runtime.Activities.Saves.Commands.ButtonCommands
{
    public sealed class UnloadSavesSceneButtonCommand : ManageScenesButtonCommand
    {
        protected override string SceneToLoadAndActivate => Scenes.Activity.Lobby;
        protected override List<string> ScenesToUnload => new() { Scenes.Activity.Saves };
        protected override List<string> ScenesToLoad => new() { Scenes.Activity.LobbyBackground };
    }
}
