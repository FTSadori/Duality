using Client.Runtime.System;
using Client.Runtime.Framework.Unity.SceneCommands;
using System.Collections.Generic;
using UnityEngine;

namespace Client.Runtime.Activities.Saves.Commands.ButtonCommands
{
    public sealed class UnloadSavesSceneButtonCommand : ChangeSceneButtonCommand
    {
        protected override string SceneToActivate => Scenes.Activity.Lobby;
        protected override List<string> ScenesToUnload => new() { Scenes.Activity.Saves };
    }
}
