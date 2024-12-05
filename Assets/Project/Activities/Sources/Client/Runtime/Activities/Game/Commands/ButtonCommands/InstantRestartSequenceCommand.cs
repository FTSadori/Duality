using Client.Runtime.Framework.Unity.SceneCommands;
using Client.Runtime.System;
using Sources.Client.Runtime.System.Bootstrap;
using UnityEngine.SceneManagement;

namespace Client.Runtime.Activities.Game.Commands.ButtonCommands
{
    public sealed class InstantRestartSequenceCommand : SequenceCommand
    {
        bool _inwoked = false;

        public override void Execute()
        {
            if (_inwoked) return;

            _inwoked = true;
            RestartBootstrapController._currentLevel = SceneManager.GetActiveScene().name;
            SceneManager.LoadSceneAsync(Scenes.Activity.RestartBootstrap, LoadSceneMode.Additive);
        }
    }
}
