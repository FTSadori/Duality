using Client.Runtime.Activities.Game.Commands.AnimationCommands;
using Client.Runtime.Activities.Lobby.Commands.AnimationCommands;
using Client.Runtime.Framework.Unity.SceneCommands;
using Client.Runtime.System;
using Sources.Client.Runtime.System.Bootstrap;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Client.Runtime.Activities.Game.Commands.ButtonCommands
{
    public sealed class RestartSequenceCommand : SequenceCommand
    {
        [SerializeField] ShowScreenSequenceCommand _screenCommand;
        [SerializeField] HideIngameMenuSequenceCommand _menuCommand;

        bool _screenCompleted = false;
        bool _menuCompleted = false;
        bool _inwoked = false;

        public override void Execute()
        {
            if (_inwoked) return;

            _inwoked = true;
            _screenCommand.OnComplete += ScreenDone;
            _menuCommand.OnComplete += MenuDone;
            _screenCommand.Execute();
            _menuCommand.Execute();
        }

        private void ScreenDone()
        {
            _screenCompleted = true;
            _screenCommand.OnComplete -= ScreenDone;
        }

        private void MenuDone()
        {
            _menuCompleted = true;
            _menuCommand.OnComplete -= MenuDone;
        }

        private void Update()
        {
            if (_screenCompleted && _menuCompleted)
            {
                GameBootstrapController._currentLevel = SceneManager.GetActiveScene().name;
                Debug.Log(GameBootstrapController._currentLevel);
                SceneManager.LoadSceneAsync(Scenes.Activity.GameBootstrap, LoadSceneMode.Additive);
                _screenCompleted = false;
                _menuCompleted = false;
            }
        }
    }
}
