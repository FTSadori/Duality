using Client.Runtime.Framework.Unity;
using Client.Runtime.System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Client.Runtime.Activities.IngameMenu.Commands.ButtonCommands
{
    public sealed class RestartLevelButtonCommand : ButtonCommand
    {
        [SerializeField] private bool _unloadIngameMenu = true;

        private string _levelName;
        private AsyncOperation _unloadOperation;
        private AsyncOperation _loadOperation;

        public override void Execute()
        {
            if (_unloadOperation != default)
            {
                return;
            }

            _levelName = SceneManager.GetActiveScene().name;
            _unloadOperation = SceneManager.UnloadSceneAsync(_levelName);
            _unloadOperation.completed += LoadScene;
        }

        private void LoadScene(AsyncOperation operation)
        {
            _loadOperation = SceneManager.LoadSceneAsync(_levelName, LoadSceneMode.Additive);
            _loadOperation.completed += ActivateScene;
        }

        private void ActivateScene(AsyncOperation operation)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(_levelName));

            if (_unloadIngameMenu)
            {
                SceneManager.UnloadSceneAsync(Scenes.Activity.IngameMenu);
            }

            Complete();
        }

        private void Complete()
        {
            if (_unloadOperation != default)
            {
                _unloadOperation.completed -= LoadScene;
            }
            _unloadOperation = default;

            if (_loadOperation != default)
            {
                _loadOperation.completed -= ActivateScene;
            }
            _loadOperation = default;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            Complete();
        }
    }
}
