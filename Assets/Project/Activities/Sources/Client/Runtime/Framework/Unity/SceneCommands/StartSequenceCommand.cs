using UnityEngine;

namespace Client.Runtime.Framework.Unity.SceneCommands
{
    public sealed class StartSequenceCommand : MonoCommand
    {
        [SerializeField] private SequenceCommand _command;

        private void Start()
        {
            _command.OnComplete += OnComplete;
            Execute();
        }

        public override void Execute()
        {
            _command.Execute();
        }

        private void OnComplete()
        {
            _command.OnComplete -= OnComplete;
            Destroy(gameObject);
        }
    }
}
