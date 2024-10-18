using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections.Generic;
using Client.Runtime.System;

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

            LoadScenes();

            if (SceneToLoadAndActivate != "")
            {
                LoadAndActivateScene();
            }
            else
            {
                UnloadScenes();
            }
        }

        private void LoadScenes()
        {
            ScenesToLoad.ForEach(s =>
            {
                if (!SceneManager.GetSceneByName(s).isLoaded && !ScenesState.IsInLoad(s))
                {
                    SceneManager.LoadSceneAsync(s, LoadSceneMode.Additive);
                    ScenesState.AddInLoad(s);
                }
            });
        }

        private void UnloadScenes()
        {
            ScenesToUnload.ForEach(s =>
            {
                if (SceneManager.GetSceneByName(s).isLoaded)
                {
                    SceneManager.UnloadSceneAsync(s);
                    ScenesState.RemoveInLoad(s);
                }
            });
        }

        private void LoadAndActivateScene()
        {
            Scene gameScene = SceneManager.GetSceneByName(SceneToLoadAndActivate);
            if (gameScene.isLoaded || ScenesState.IsInLoad(SceneToLoadAndActivate))
            {
                return;
            }

            ScenesState.AddInLoad(SceneToLoadAndActivate);
            _operation = SceneManager.LoadSceneAsync(SceneToLoadAndActivate, LoadSceneMode.Additive);
            _operation.completed += ActivateScene;
        }

        private void ActivateScene(AsyncOperation operation)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(SceneToLoadAndActivate));

            UnloadScenes();

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
