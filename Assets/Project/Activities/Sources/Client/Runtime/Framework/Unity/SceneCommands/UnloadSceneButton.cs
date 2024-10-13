using Client.Runtime.Framework.Unity;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace Client.Runtime.Framework.Unity.SceneCommands
{
    public abstract class UnloadSceneButton : ButtonCommand
    {
        abstract protected List<string> ScenesToUnload { get; }

        public override void Execute()
        {
            ScenesToUnload.ForEach(s => SceneManager.UnloadSceneAsync(s));
        }
    }
}
