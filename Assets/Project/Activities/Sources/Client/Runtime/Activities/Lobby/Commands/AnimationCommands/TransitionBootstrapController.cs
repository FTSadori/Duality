using Client.Runtime.Framework.Unity.SceneCommands;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Client.Runtime.Activities.Lobby.Commands.AnimationCommands
{
    public sealed class TransitionBootstrapController : MonoBehaviour
    {
        [SerializeField] SequenceCommand _startCommand;
        [SerializeField] SequenceCommand _endCommand;

        public static ManageScenesCommand _manageCommand;

        private void Awake()
        {
            _startCommand.OnComplete += Manage;
            _manageCommand.OnComplete += Leave;
            _endCommand.OnComplete += Complete;
            _startCommand.Execute();
        }

        private void Manage()
        {
            _manageCommand.Execute();
        }

        private void Leave()
        {
            _endCommand.Execute();
        }

        private void Complete()
        {
            _startCommand.OnComplete -= Manage;
            _manageCommand.OnComplete -= Leave;
            _endCommand.OnComplete -= Complete;

            SceneManager.UnloadSceneAsync(gameObject.scene.name);
        }

        private void OnDestroy()
        {
            Complete();
        }
    }
}
