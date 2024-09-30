using Client.Runtime.Framework.Unity;
using UnityEngine.SceneManagement;

namespace Client.Runtime.Activities.Saves.Commands.ButtonCommands
{
    public sealed class UnloadSceneButtonCommand : ButtonCommand
    {
        public override void Execute()
        {
            SceneManager.UnloadSceneAsync(gameObject.scene.name);
        }
    }
}
