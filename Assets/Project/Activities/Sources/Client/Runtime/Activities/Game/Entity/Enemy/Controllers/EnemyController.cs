﻿using Client.Runtime.Framework.Unity;
using UnityEngine;

namespace Client.Runtime.Activities.Game.Entity.Enemy.Controllers
{
    public sealed class EnemyController : MonoBehaviour
    {
        [Header("Main")]
        [SerializeField] private int _startMaxHp;
        [SerializeField] private float _knockbackResistance;

        [Header("Commands")]
        [SerializeField] private MonoCommand _attackMoving;
        [SerializeField] private MonoCommand _idleMoving;
        [SerializeField] private MonoCommand _attack;
        [SerializeField] private MonoCommand _onDeath;

        public EnemyModel Model { get; private set; }

        private void Awake()
        {
            Model = new EnemyModel(_startMaxHp, _knockbackResistance);
        }
    }
}