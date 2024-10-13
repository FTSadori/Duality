using System;
using UnityEngine;
using UnityEngine.UI;

namespace Client.Runtime.Framework.Unity
{
    public abstract class ButtonCommand : MonoCommand
    {
        [SerializeField] private Button _button;

        public void Awake()
        {
            _button.onClick.AddListener(Execute);
        }

        protected virtual void OnDestroy()
        {
            _button.onClick.RemoveListener(Execute);
        }
    }
}
