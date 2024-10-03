using Client.Runtime.Framework.Unity.SceneCommands;
using Client.Runtime.System;
using System.Collections.Generic;

namespace Client.Runtime.Activities.Tutorial.Commands.ButtonCommands
{
    public sealed class ShowIngameMenuButtonCommand : ManageScenesButtonCommand
    {
        protected override string SceneToLoadAndActivate => "";
        protected override List<string> ScenesToUnload => new();
        protected override List<string> ScenesToLoad => new() { Scenes.Activity.IngameMenu };
    }
}
