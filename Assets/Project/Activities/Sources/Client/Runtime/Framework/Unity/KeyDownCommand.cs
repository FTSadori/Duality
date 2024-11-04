using UnityEngine;

namespace Client.Runtime.Framework.Unity
{
    public abstract class KeyDownCommand : MonoCommand
    {
        [SerializeField] private KeyCode _keyCode;

        private void Update()
        {
            if (Input.GetKeyDown(_keyCode))
            {
                Execute();
            }
        }
    }
}
