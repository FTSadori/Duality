using Client.Runtime.Framework.Unity.SceneCommands;
using Client.Runtime.System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace Client.Runtime.Activities.Game.Commands.ButtonCommands
{
    public sealed class BackToLobbyScenesCommand : ManageScenesCommand
    {
        protected override string SceneToLoadAndActivate => Scenes.Activity.LobbyBackground;

        protected override List<string> ScenesToUnload => new() { Scenes.Activity.GameGUI, Scenes.Activity.Tutorial };

        protected override List<string> ScenesToLoad => new() { Scenes.Activity.Lobby };
    }
}
