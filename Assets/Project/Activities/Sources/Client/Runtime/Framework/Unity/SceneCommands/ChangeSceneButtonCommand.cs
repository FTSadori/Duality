using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections.Generic;

namespace Client.Runtime.Framework.Unity.SceneCommands
{
    public abstract class ChangeSceneButtonCommand : ButtonCommand
    {
        private AsyncOperation _operation;
        abstract protected string SceneToActivate { get; }
        abstract protected List<string> ScenesToUnload { get; }

        public override void Execute()
        {
            if (_operation != default)
            {
                return;
            }

            Scene gameScene = SceneManager.GetSceneByName(SceneToActivate);
            if (gameScene != default && gameScene.isLoaded)
            {
                return;
            }

            _operation = SceneManager.LoadSceneAsync(SceneToActivate, LoadSceneMode.Additive);
            _operation.completed += ActivateScene;
        }

        private void ActivateScene(AsyncOperation operation)
        {
            ScenesToUnload.ForEach(s => SceneManager.UnloadSceneAsync(s));
            
            Scene gameScene = SceneManager.GetSceneByName(SceneToActivate);
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
