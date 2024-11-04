using UnityEngine;

namespace Client.Runtime.Framework.Unity
{
    public abstract class KeyCommand : MonoCommand
    {
        [SerializeField] private KeyCode _keyCode;

        private void Update()
        {
            if (Input.GetKey(_keyCode))
            {
                Execute();
            }
        }
    }
}
