
using Client.Runtime.Activities.Game.Controllers;
using Client.Runtime.Activities.Game.Entity.Enemy;
using Client.Runtime.Framework.Presenter;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace Client.Runtime.Activities.Game.Player
{
    public sealed class PlayerPresenter : MonoPresenter
    {
        [SerializeField] private PlayerView _playerView;

        [Inject] private readonly PlayerModel _playerModel;

        private void Awake()
        {
            Assert.IsNotNull(_playerView, "[PlayerPresenter] PlayerView is required");
        }

        private void PlayerGotHit(GameObject gameObject)
        {
            if (gameObject.TryGetComponent(out BulletController bulletController))
            {
                _playerModel.CurrentHP -= bulletController.ContactDamage;
                _playerView.Rigidbody.AddForce(bulletController._forceVector, ForceMode2D.Impulse);
                bulletController.AfterEnemyHit();
            }
        }

        private void PlayerGotContact(GameObject gameObject)
        {
            float force = 10f;

            if (gameObject.TryGetComponent(out EnemyView enemyView))
            {
                _playerModel.CurrentHP -= enemyView.ContactDamage;
                _playerView.Rigidbody.AddForce((_playerView.Rigidbody.position - enemyView.Rigidbody.position).normalized * force, ForceMode2D.Impulse);
            }
        }

        private void ModelHpChanged()
        {
            Debug.Log($"Player HP {_playerModel.CurrentHP} / {_playerModel.MaxHP}");
        }

        public override void Enable()
        {
            _playerView.OnGotHit += PlayerGotHit;
            _playerView.OnGotContact += PlayerGotContact;

            _playerModel.OnHPChanged += ModelHpChanged;
        }

        public override void Disable()
        {
            _playerView.OnGotHit -= PlayerGotHit;
            _playerView.OnGotContact -= PlayerGotContact;

            _playerModel.OnHPChanged -= ModelHpChanged;
        }
    }
}
