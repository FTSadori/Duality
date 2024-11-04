using Client.Runtime.Activities.Lobby.Commands.AnimationCommands;
using Client.Runtime.System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Client.Runtime.Framework.Unity.SceneCommands
{
    public sealed class TransitionedManageScenesButtonCommand : ButtonCommand
    {
        [SerializeField] private ManageScenesCommand _manageCommand;
        private bool _isFree = true;
        
        public override void Execute()
        {
            if (_isFree)
            {
                _isFree = false;
                TransitionBootstrapController._manageCommand = _manageCommand;
                SceneManager.LoadSceneAsync(Scenes.Activity.TransitionBootstrap, LoadSceneMode.Additive);
            }
        }
    }
}
