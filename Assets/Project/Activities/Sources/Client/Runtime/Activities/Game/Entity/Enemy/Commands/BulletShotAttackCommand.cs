using Client.Runtime.Activities.Game.Controllers;
using Client.Runtime.Activities.Game.Player;
using Client.Runtime.Activities.Game.ScriptableObjects;
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
        [SerializeField] private BulletScriptableObject _bulletObject;
        [SerializeField] private int _bulletCount = 3;
        [SerializeField] private float _angleRange = 45f;
        [SerializeField] private float _timeBetweenAttacks = 2f;
        private float _attacksTimer = -1f;
        
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
                InstantiateButton(angle);

                if (_bulletCount != 1)
                {
                    angle += _angleRange / (_bulletCount - 1);
                }
            }
        }

        private void InstantiateButton(float angle)
        {
            var direction = new Vector3(Mathf.Cos(angle / 180 * Mathf.PI), Mathf.Sin(angle / 180 * Mathf.PI));
            var obj = Instantiate(_bulletPrefab, _rigidbody.transform.position + direction, Quaternion.Euler(0, 0, angle));
            obj.transform.localScale = _bulletObject._baseScale * Vector3.one;

            if (obj.TryGetComponent(out SpriteRenderer spriteRenderer))
            {
                spriteRenderer.color = _bulletObject._color;
            }

            if (obj.TryGetComponent(out BulletController bulletController))
            {
                bulletController._bulletScriptableObject = _bulletObject;
                bulletController.Rb.velocity = _bulletObject._speed * direction;
                bulletController._forceVector = _bulletObject._force * direction;
            }
        }
    }
}
