using Client.Runtime.Framework.Unity.SceneCommands;
using Client.Runtime.System;
using System.Collections.Generic;

namespace Client.Runtime.Activities.IngameMenu.Commands.ButtonCommands
{
    public sealed class CloseIngameMenuButtonCommand : UnloadSceneButton
    {
        protected override List<string> ScenesToUnload => new() { Scenes.Activity.IngameMenu };
    }
}
