using Client.Runtime.Activities.Game.Commands.AnimationCommands;
using Client.Runtime.Framework.Unity.SceneCommands;
using Client.Runtime.System;
using Sources.Client.Runtime.System.Bootstrap;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Client.Runtime.Activities.Game.Commands.ButtonCommands
{
    public sealed class RestartSequenceCommand : SequenceCommand
    {
        [SerializeField] HideIngameMenuSequenceCommand _menuCommand;

        bool _inwoked = false;

        public override void Execute()
        {
            if (_inwoked) return;

            _inwoked = true;
            _menuCommand.OnComplete += MenuDone;
            _menuCommand.Execute();
        }

        private void MenuDone()
        {
            _menuCommand.OnComplete -= MenuDone;

            RestartBootstrapController._currentLevel = SceneManager.GetActiveScene().name;
            SceneManager.LoadSceneAsync(Scenes.Activity.RestartBootstrap, LoadSceneMode.Additive);
        }
    }
}
