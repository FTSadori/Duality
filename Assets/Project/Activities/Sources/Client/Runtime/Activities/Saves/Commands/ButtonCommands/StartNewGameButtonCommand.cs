﻿using Client.Runtime.Framework.Unity.SceneCommands;
using Client.Runtime.System;
using System.Collections.Generic;
using UnityEngine;

namespace Client.Runtime.Activities.Saves.Commands.ButtonCommands
{
    public sealed class StartNewGameButtonCommand : ChangeSceneButtonCommand
    {
        // doto: is going to be used later
        [SerializeField] private int _saveNumber;
        protected override string SceneToActivate => Scenes.Activity.TutorialStart;
        protected override List<string> ScenesToUnload => new() { Scenes.Activity.Saves, Scenes.Activity.LobbyBackground };
    }
}
