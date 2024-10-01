using Client.Runtime.Framework.Unity;
using UnityEngine.SceneManagement;

namespace Assets.Project.Activities.Sources.Client.Runtime.Activities.Saves.Commands.ButtonCommands
{
    public sealed class UnloadSavesSceneKeyDownCommand : KeyDownCommand
    {
        public override void Execute()
        {
            SceneManager.UnloadSceneAsync(gameObject.scene.name);
        }
    }
}
