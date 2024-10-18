using UnityEngine;

namespace Client.Runtime.Framework.Unity
{
    public abstract class KeyUpCommand : MonoCommand
    {
        [SerializeField] private KeyCode _keyCode;

        private void Update()
        {
            if (Input.GetKeyUp(_keyCode))
            {
                Execute();
            }
        }
    }
}
