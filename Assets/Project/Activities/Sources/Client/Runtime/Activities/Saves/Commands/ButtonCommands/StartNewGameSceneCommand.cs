﻿using Client.Runtime.Framework.Unity.SceneCommands;
using Client.Runtime.System;
using System.Collections.Generic;
using UnityEngine;

namespace Client.Runtime.Activities.Saves.Commands.ButtonCommands
{
    public sealed class StartNewGameSceneCommand : ManageScenesCommand
    {
        // todo: is going to be used later
        [SerializeField] private int _saveNumber;
        protected override string SceneToLoadAndActivate => Scenes.Activity.Tutorial;
        protected override List<string> ScenesToUnload => new() { Scenes.Activity.Lobby, Scenes.Activity.LobbyBackground };
        protected override List<string> ScenesToLoad => new() { };
    }
}
