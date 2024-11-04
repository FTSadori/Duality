using UnityEngine;

namespace Client.Runtime.Framework.Unity.SceneCommands
{
    public sealed class PopUpButtonCommand : ButtonCommand
    {
        [SerializeField] private SequenceCommand _hideSequence;
        [SerializeField] private SequenceCommand _showSequence;
        private bool _isFree = true;

        public override void Execute()
        {
            if (_isFree)
            {
                _isFree = false;
                _hideSequence.OnComplete += Show;
                _hideSequence.Execute();
            }
        }

        private void Show()
        {
            _hideSequence.OnComplete -= Show;
            _showSequence.OnComplete += Free;
            _showSequence.Execute();
        }

        private void Free()
        {
            _isFree = true;
            _showSequence.OnComplete -= Free;
        }
    }
}
