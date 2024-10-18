using Client.Runtime.Framework.Command;
using UnityEngine;

namespace Client.Runtime.Framework.Unity
{
    public abstract class MonoCommand : MonoBehaviour, ICommand
    {
        public abstract void Execute();
    }
}
