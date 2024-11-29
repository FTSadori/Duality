using Client.Runtime.Activities.Lobby.Commands.AnimationCommands;
using Client.Runtime.Framework.Unity.SceneCommands;
using Client.Runtime.System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sources.Client.Runtime.System.Bootstrap
{
    public sealed class RestartBootstrapController : MonoBehaviour
    {
        public static string _currentLevel = "";

        [SerializeField] private ShowScreenSequenceCommand _showScreen;
        [SerializeField] private HideScreenSequenceCommand _hideScreen;

        private AsyncOperation _unloadLevelOperation;
        private AsyncOperation _loadLevelOperation;
        private bool _isLevelLoaded = false;

        private AsyncOperation _unloadGUIOperation;
        private AsyncOperation _loadGUIOperation;
        private bool _isGUIUnloaded = false;

        private void Awake()
        {
            _showScreen.OnComplete += AfterScreen;
            _hideScreen.OnComplete += Complete;
            _showScreen.Execute();
        }

        private void AfterScreen()
        {
            _showScreen.OnComplete -= AfterScreen;
            _unloadLevelOperation = SceneManager.UnloadSceneAsync(_currentLevel);
            _unloadLevelOperation.completed += OnLevelSceneUnloaded;

            _unloadGUIOperation = SceneManager.UnloadSceneAsync(Scenes.Activity.GameGUI);
            _unloadGUIOperation.completed += OnGUISceneUnloaded;
        }

        private void OnLevelSceneUnloaded(AsyncOperation operation)
        {
            _loadLevelOperation = SceneManager.LoadSceneAsync(_currentLevel, LoadSceneMode.Additive);
            _loadLevelOperation.completed += OnLevelSceneLoaded;
        }

        private void OnGUISceneUnloaded(AsyncOperation operation)
        {
            _isGUIUnloaded = operation.isDone;
        }

        private void OnLevelSceneLoaded(AsyncOperation operation)
        {
            _isLevelLoaded = operation.isDone;
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(_currentLevel));
        }

        private void Update()
        {
            if (_isLevelLoaded && _isGUIUnloaded)
            {
                _isLevelLoaded = false;
                _hideScreen.Execute();
            }
        }

        private void Complete()
        {
            _hideScreen.OnComplete -= Complete;
            SceneManager.UnloadSceneAsync(gameObject.scene.name);
        }

        private void OnDestroy()
        {
            _unloadGUIOperation.completed -= OnGUISceneUnloaded;
            _unloadLevelOperation.completed -= OnLevelSceneUnloaded;
            _loadLevelOperation.completed -= OnLevelSceneLoaded;
        }
    }
}
