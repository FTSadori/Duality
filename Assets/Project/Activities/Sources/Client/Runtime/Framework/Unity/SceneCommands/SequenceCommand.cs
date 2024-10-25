using System;

namespace Client.Runtime.Framework.Unity.SceneCommands
{
    public abstract class SequenceCommand : MonoCommand
    {
        public Action OnComplete;
    }
}
