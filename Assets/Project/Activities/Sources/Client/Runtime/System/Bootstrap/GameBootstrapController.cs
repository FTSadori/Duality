﻿using Client.Runtime.System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sources.Client.Runtime.System.Bootstrap
{
    public sealed class GameBootstrapController : MonoBehaviour
    {
        public static string _currentLevel = "";

        private AsyncOperation _unloadLevelOperation;
        private AsyncOperation _loadLevelOperation;
        private bool _isLevelLoaded = false;

        private AsyncOperation _unloadGUIOperation;
        private AsyncOperation _loadGUIOperation;
        private bool _isGUILoaded = false;

        private void Awake()
        {
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
            _loadGUIOperation = SceneManager.LoadSceneAsync(Scenes.Activity.GameGUI, LoadSceneMode.Additive);
            _loadGUIOperation.completed += OnGUISceneLoaded;
        }

        private void OnLevelSceneLoaded(AsyncOperation operation)
        {
            _isLevelLoaded = operation.isDone;
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(_currentLevel));
        }

        private void OnGUISceneLoaded(AsyncOperation operation)
        {
            _isGUILoaded = operation.isDone;
        }

        private void Update()
        {
            if (_isLevelLoaded && _isGUILoaded)
            {
                SceneManager.UnloadSceneAsync(gameObject.scene.name);
            }
        }

        private void OnDestroy()
        {
            _unloadGUIOperation.completed -= OnGUISceneUnloaded;
            _unloadLevelOperation.completed -= OnLevelSceneUnloaded;
            _loadLevelOperation.completed -= OnLevelSceneLoaded;
            _loadGUIOperation.completed -= OnGUISceneLoaded;
        }
    }
}