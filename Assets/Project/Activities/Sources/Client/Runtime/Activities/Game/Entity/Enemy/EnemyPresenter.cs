﻿using Client.Runtime.Activities.Game.Controllers;
using Client.Runtime.Activities.Game.Entity.Enemy.Controllers;
using Client.Runtime.Framework.Presenter;
using UnityEngine;
using UnityEngine.Assertions;

namespace Client.Runtime.Activities.Game.Entity.Enemy
{
    public sealed class EnemyPresenter : MonoPresenter
    {
        [SerializeField] private EnemyView _enemyView;
        [SerializeField] private EnemyController _enemyController;

        private void Awake()
        {
            Assert.IsNotNull(_enemyView, "[EnemyPresenter] EnemyView is required");
            Assert.IsNotNull(_enemyController, "[EnemyPresenter] EnemyController is required");
        }

        private void Start()
        {
            Enable();
        }

        private void EntityGotHit(GameObject gameObject)
        {
            if (gameObject.TryGetComponent(out BulletController bulletController))
            {
                _enemyController.Model.CurrentHP -= bulletController.ContactDamage;
                _enemyView.Rigidbody.AddForce(bulletController._forceVector, ForceMode2D.Impulse);
                bulletController.AfterEnemyHit();
            }
        }

        private void ModelHpChanged()
        {
            Debug.Log($"Enemy HP {_enemyController.Model.CurrentHP} / {_enemyController.Model.MaxHP}");
        }

        public override void Enable()
        {
            _enemyView.OnGotHit += EntityGotHit;
            _enemyController.Model.OnHPChanged += ModelHpChanged;
        }

        public override void Disable()
        {
            _enemyView.OnGotHit -= EntityGotHit;
            _enemyController.Model.OnHPChanged -= ModelHpChanged;
        }

        private void OnDestroy()
        {
            Disable();
        }
    }
}