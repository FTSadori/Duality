using Client.Runtime.Framework.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Sources.Client.Runtime.Framework.Unity
{
    public abstract class MonoCommand : MonoBehaviour, ICommand
    {
        public abstract void Execute();
    }
}
