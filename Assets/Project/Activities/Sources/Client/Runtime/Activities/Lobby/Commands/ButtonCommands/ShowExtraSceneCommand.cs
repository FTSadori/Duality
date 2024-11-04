using Client.Runtime.Framework.Unity.SceneCommands;
using Client.Runtime.System;
using System.Collections.Generic;

namespace Client.Runtime.Activities.Lobby.Commands.ButtonCommands
{
    public sealed class ShowExtraSceneCommand : ManageScenesCommand
    {
        protected override string SceneToLoadAndActivate => Scenes.Activity.Extra;
        protected override List<string> ScenesToUnload => new() { Scenes.Activity.Lobby, Scenes.Activity.LobbyBackground };
        protected override List<string> ScenesToLoad => new() { };
    }
}
