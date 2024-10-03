using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections.Generic;

namespace Client.Runtime.Framework.Unity.SceneCommands
{
    public abstract class ManageScenesButtonCommand : ButtonCommand
    {
        private AsyncOperation _operation;
        abstract protected string SceneToLoadAndActivate { get; }
        abstract protected List<string> ScenesToUnload { get; }
        abstract protected List<string> ScenesToLoad { get; }

        public override void Execute()
        {
            if (_operation != default)
            {
                return;
            }

            ScenesToLoad.ForEach(s =>
            {
                if (!SceneManager.GetSceneByName(s).isLoaded)
                {
                    SceneManager.LoadSceneAsync(s, LoadSceneMode.Additive);
                }
            });
            ScenesToUnload.ForEach(s =>
            {
                if (SceneManager.GetSceneByName(s).isLoaded)
                {
                    SceneManager.UnloadSceneAsync(s);
                }
            });
            
            if (SceneToLoadAndActivate != "")
                LoadAndActivateScene();
        }

        private void LoadAndActivateScene()
        {
            Scene gameScene = SceneManager.GetSceneByName(SceneToLoadAndActivate);
            if (gameScene != default && gameScene.isLoaded)
            {
                return;
            }

            _operation = SceneManager.LoadSceneAsync(SceneToLoadAndActivate, LoadSceneMode.Additive);
            _operation.completed += ActivateScene;
        }

        private void ActivateScene(AsyncOperation operation)
        {
            Scene gameScene = SceneManager.GetSceneByName(SceneToLoadAndActivate);
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
