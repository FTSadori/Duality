using Client.Runtime.Framework.Unity;
using Client.Runtime.System;
using UnityEngine.SceneManagement;

namespace Client.Runtime.Activities.Game.Commands
{
    public sealed class LoadGuiCommand : MonoCommand
    {
        public override void Execute()
        {
            SceneManager.LoadSceneAsync(Scenes.Activity.GameGUI, LoadSceneMode.Additive);
            ScenesState.AddInLoad(Scenes.Activity.GameGUI);
        }

        private void Awake()
        {
            Execute();
        }
    }
}
