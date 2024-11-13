using Client.Runtime.Activities.Game.Controllers;
using Client.Runtime.Activities.Game.Player;
using Client.Runtime.Framework.Unity;
using UnityEngine;
using UnityEngine.Assertions;

namespace Client.Runtime.Activities.Game.Entity.Enemy.Commands
{
    public sealed class BulletShotAttackCommand : MonoCommand
    {
        [Header("Links")]
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private PlayerView _playerView;

        private void Awake()
        {
            Assert.IsNotNull(_playerView, "[BulletShotAttackCommand] EnemyView is required");
            Assert.IsNotNull(_rigidbody, "[BulletShotAttackCommand] Rigidbody2D is required");
        }

        [Header("Stats")]
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private int _bulletCount = 3;
        [SerializeField] private float _angleRange = 45f;
        [SerializeField] private float _timeBetweenAttacks = 2f;
        [SerializeField] private float _bulletSpeed = 3f;
        private float _attacksTimer = -1f;
        private float _bulletForce = 10f;

        public override void Execute()
        {
            if (_attacksTimer < 0f)
            {
                var toPlayer = (_playerView.FixedPosition - _rigidbody.transform.position).normalized;
                AttackPlayer(toPlayer);
            }
            else
                _attacksTimer -= Time.deltaTime;
        }

        private void AttackPlayer(Vector3 toPlayer)
        {
            _attacksTimer = _timeBetweenAttacks;

            float toPlayerAngle = Vector2.Angle(Vector2.right, toPlayer);
            if (_playerView.FixedPosition.y < _rigidbody.transform.position.y)
                toPlayerAngle *= -1;

            float angle = toPlayerAngle - _angleRange / 2f;
            for (int i = 0; i < _bulletCount; ++i)
            {
                var direction = new Vector3(Mathf.Cos(angle / 180 * Mathf.PI), Mathf.Sin(angle / 180 * Mathf.PI));
                var obj = Instantiate(_bulletPrefab, _rigidbody.transform.position + direction, Quaternion.Euler(0, 0, angle));

                if (obj.TryGetComponent(out BulletController bulletController))
                {
                    bulletController.Rb.velocity = _bulletSpeed * direction;
                    bulletController._forceVector = _bulletForce * direction;
                }

                if (_bulletCount != 1)
                {
                    angle += _angleRange / (_bulletCount - 1);
                }
            }
        }
    }
}
