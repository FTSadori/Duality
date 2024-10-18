using Client.Runtime.Framework.Unity;
using UnityEngine;

namespace Client.Runtime.Activities.Game.Entity.Enemy.Commands
{
    public sealed class SimpleDeathCommand : MonoCommand
    {
        [SerializeField] private GameObject _parentObject;
        [SerializeField] private float _deathTime;

        public override void Execute()
        {
            Destroy(_parentObject, _deathTime);
        }
    }
}
