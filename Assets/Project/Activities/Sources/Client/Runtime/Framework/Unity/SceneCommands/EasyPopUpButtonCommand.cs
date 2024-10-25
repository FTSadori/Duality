using UnityEngine;

namespace Client.Runtime.Framework.Unity.SceneCommands
{
    public sealed class EasyPopUpButtonCommand : ButtonCommand
    {
        [SerializeField] private SequenceCommand _command;
        private bool _isFree = true;

        public override void Execute()
        {
            if (_isFree)
            {
                _isFree = false;
                _command.Execute();
                _command.OnComplete += Free;
            }
        }

        private void Free()
        {
            _command.OnComplete -= Free;
            _isFree = true;
        }
    }
}
