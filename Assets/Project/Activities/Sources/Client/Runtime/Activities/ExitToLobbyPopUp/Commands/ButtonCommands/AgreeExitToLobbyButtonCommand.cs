using Client.Runtime.Framework.Unity.SceneCommands;
using Client.Runtime.System;
using System.Collections.Generic;

namespace Client.Runtime.Activities.ExitToLobbyPopUp.Commands.ButtonCommands
{
    public sealed class AgreeExitToLobbyButtonCommand : ManageScenesButtonCommand
    {
        protected override string SceneToLoadAndActivate => Scenes.Activity.LobbyBackground;
        protected override List<string> ScenesToUnload => new() { Scenes.Activity.ExitToLobbyPopUp, Scenes.Activity.IngameMenu, Scenes.Activity.GameGUI, Scenes.Activity.Tutorial };
        protected override List<string> ScenesToLoad => new() { Scenes.Activity.Lobby };
    }
}
