using Client.Runtime.Framework.Unity.SceneCommands;
using Client.Runtime.System;
using System.Collections.Generic;

namespace Client.Runtime.Activities.ExitToLobbyPopUp.Commands.ButtonCommands
{
    public sealed class DisagreeExitToLobbyButtonCommand : UnloadSceneButton
    {
        protected override List<string> ScenesToUnload => new() { Scenes.Activity.ExitToLobbyPopUp };
    }
}
