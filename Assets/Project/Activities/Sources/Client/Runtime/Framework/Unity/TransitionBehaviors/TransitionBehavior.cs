using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Client.Runtime.Framework.Unity.TransitionBehaviors
{
    public abstract class TransitionBehavior : MonoBehaviour
    {
        public bool IsDone => _isDone;

        private bool _isDone = false;

        private void Update()
        {
            if (_isDone) return;
            _isDone = Transition();
        }

        public abstract bool Transition();
    }
}
