using UnityEngine;

namespace Client.Runtime.Framework.Unity.SceneCommands
{
    public sealed class TransitionedManageScenesButtonCommand : ButtonCommand
    {
        [SerializeField] private SequenceCommand _outSequence;
        [SerializeField] private ManageScenesCommand _manageCommand;
        private bool _isFree = true;
        
        public override void Execute()
        {
            if (_isFree)
            {
                _isFree = false;
                _outSequence.OnComplete += Manage;
                _outSequence.Execute();
            }
        }

        private void Manage()
        {
            _outSequence.OnComplete -= Manage;
            _manageCommand.Execute();
        }
    }
}
