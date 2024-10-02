using UnityEngine;
using UnityEngine.SceneManagement;

namespace Client.Runtime.System.Bootstrap
{ 
    public sealed class BootstrapController : MonoBehaviour 
    {
        private AsyncOperation _loadLobbyOperation;
        private bool _isLobbyLoaded = false;

        private AsyncOperation _loadBackgroundOperation;
        private bool _isBackgroundLoaded = false;

        private void Awake()
        {
            SceneManager.LoadSceneAsync(Scenes.System.MainCamera, LoadSceneMode.Additive);
            SceneManager.LoadSceneAsync(Scenes.System.Input, LoadSceneMode.Additive);
            SceneManager.LoadSceneAsync(Scenes.System.Audio, LoadSceneMode.Additive);
            _loadLobbyOperation = SceneManager.LoadSceneAsync(Scenes.Activity.Lobby, LoadSceneMode.Additive);
            _loadLobbyOperation.completed += OnLobbySceneLoaded;
            _loadBackgroundOperation = SceneManager.LoadSceneAsync(Scenes.Activity.LobbyBackground, LoadSceneMode.Additive);
            _loadBackgroundOperation.completed += OnBackgroundSceneLoaded;
        }

        private void OnLobbySceneLoaded(AsyncOperation operation)
        {
            _isLobbyLoaded = operation.isDone;
        }

        private void OnBackgroundSceneLoaded(AsyncOperation operation)
        {
            _isBackgroundLoaded = operation.isDone;
        }

        private void Update()
        {
            if (_isLobbyLoaded && _isBackgroundLoaded)
            {
                SceneManager.UnloadSceneAsync(gameObject.scene.name);
            }
        }

        private void OnDestroy()
        {
            _loadLobbyOperation.completed -= OnLobbySceneLoaded;
        }
    }
}