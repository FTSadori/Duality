using UnityEngine;

namespace Client.Runtime.Framework.Unity
{
    public sealed class AlternativeKeyDownCommand : KeyDownCommand
    {
        [SerializeField] private ButtonCommand _alternativeCommand;

        public override void Execute()
        {
            _alternativeCommand?.Execute();
        }
    }
}
