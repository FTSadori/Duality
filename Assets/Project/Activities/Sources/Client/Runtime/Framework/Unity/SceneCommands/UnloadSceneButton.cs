using Client.Runtime.Framework.Unity;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace Client.Runtime.Framework.Unity.SceneCommands
{
    public abstract class UnloadSceneButton : ManageScenesCommand
    {
        protected override string SceneToLoadAndActivate => "";
        protected override List<string> ScenesToLoad => new() { };
    }
}
