using System.Collections.Generic;

namespace Client.Runtime.Framework.Unity.SceneCommands
{
    public abstract class LoadSceneButton : ManageScenesButtonCommand
    {
        protected override string SceneToLoadAndActivate => "";
        protected override List<string> ScenesToUnload => new() { };
    }
}
