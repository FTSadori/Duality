using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections.Generic;
using Client.Runtime.System;
using System;

namespace Client.Runtime.Framework.Unity.SceneCommands
{
    public abstract class ManageScenesCommand : MonoCommand
    {
        abstract protected string SceneToLoadAndActivate { get; }
        abstract protected List<string> ScenesToUnload { get; }
        abstract protected List<string> ScenesToLoad { get; }

        private static List<AsyncOperation> _unloadOperations = new();
        private static List<AsyncOperation> _loadOperations = new();
        private bool _isBuzy = false;
        private object _lockUnload = new();
        private object _lockLoad = new();
        private int _numUnloaded = 0;
        private int _numLoaded = 0;

        public Action OnComplete;

        public override void Execute()
        {
            if (_isBuzy)
            {
                return;
            }

            UnloadScenes();

            _isBuzy = true;
        }

        private void LoadScenes()
        {
            ScenesToLoad.ForEach(s =>
            {
                if (!SceneManager.GetSceneByName(s).isLoaded && !ScenesState.IsInLoad(s))
                {
                    _loadOperations.Add(SceneManager.LoadSceneAsync(s, LoadSceneMode.Additive));
                    _loadOperations[^1].completed += AddLoad;
                    ScenesState.AddInLoad(s);
                }
            });

            if (!SceneManager.GetSceneByName(SceneToLoadAndActivate).isLoaded && 
                !ScenesState.IsInLoad(SceneToLoadAndActivate) && 
                SceneToLoadAndActivate != "")
            {
                _loadOperations.Add(SceneManager.LoadSceneAsync(SceneToLoadAndActivate, LoadSceneMode.Additive));
                _loadOperations[^1].completed += AddLoad;
                ScenesState.AddInLoad(SceneToLoadAndActivate);
            }
        }

        private void AddLoad(AsyncOperation a)
        {
            lock (_lockLoad) { 
                _numLoaded++;

                if (_loadOperations.Count == _numLoaded)
                {
                    _numLoaded++;
                    if (SceneToLoadAndActivate != "")
                    {
                        SceneManager.SetActiveScene(SceneManager.GetSceneByName(SceneToLoadAndActivate));
                    }
                    Complete();
                }
            }
        }

        private void UnloadScenes()
        {
            ScenesToUnload.ForEach(s =>
            {
                if (SceneManager.GetSceneByName(s).isLoaded)
                {
                    _unloadOperations.Add(SceneManager.UnloadSceneAsync(s));
                    _unloadOperations[^1].completed += AddUnload;
                    ScenesState.RemoveInLoad(s);
                }
            });
        }

        private void AddUnload(AsyncOperation a)
        {
            lock (_lockUnload) {
                _numUnloaded++;
                if (_unloadOperations.Count == _numUnloaded)
                {
                    _numUnloaded++;
                    LoadScenes();
                }
            }
        }

        private void Complete()
        {
            _unloadOperations.ForEach(o => o.completed -= AddUnload);
            _loadOperations.ForEach(o => o.completed -= AddLoad);

            _unloadOperations.Clear();
            _loadOperations.Clear();
            _numUnloaded = 0;
            _numLoaded = 0;

            _isBuzy = false;

            OnComplete();
        }
    }
}
