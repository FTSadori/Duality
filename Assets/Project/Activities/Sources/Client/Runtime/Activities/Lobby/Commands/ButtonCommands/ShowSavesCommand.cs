using Client.Runtime.Framework.Unity;
using UnityEngine.SceneManagement;
using UnityEngine;
using Client.Runtime.System;

namespace Client.Runtime.Activities.Lobby.Commands.ButtonCommands
{
    public sealed class ShowSavesCommand : ButtonCommand
    {
        private AsyncOperation _operation;

        public override void Execute()
        {
            if (_operation != default)
            {
                return;
            }

            Scene gameScene = SceneManager.GetSceneByName(Scenes.Activity.Saves);
            if (gameScene != default && gameScene.isLoaded)
            {
                return;
            }

            _operation = SceneManager.LoadSceneAsync(Scenes.Activity.Saves, LoadSceneMode.Additive);
            _operation.completed += ActivateScene;
        }

        private void ActivateScene(AsyncOperation operation)
        {
            Scene gameScene = SceneManager.GetSceneByName(Scenes.Activity.Saves);
            if (gameScene != default)
            {
                SceneManager.SetActiveScene(gameScene);
            }

            Complete();
        }

        private void Complete()
        {
            if (_operation != default)
            {
                _operation.completed -= ActivateScene;
            }
            _operation = default;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            Complete();
        }
    }
}
