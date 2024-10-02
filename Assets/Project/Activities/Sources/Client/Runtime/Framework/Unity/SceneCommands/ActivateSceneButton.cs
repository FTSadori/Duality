using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Client.Runtime.Framework.Unity.SceneCommands
{
    public abstract class ActivateSceneButton : ChangeSceneButtonCommand
    {
        protected override List<string> ScenesToUnload => new() { };
    }
}
