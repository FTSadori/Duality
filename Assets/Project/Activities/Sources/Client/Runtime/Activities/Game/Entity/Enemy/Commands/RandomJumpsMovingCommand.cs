using Client.Runtime.Activities.Game.Player;
using Client.Runtime.Framework.Unity;
using System.Threading;
using UnityEngine;
using UnityEngine.Assertions;

namespace Client.Runtime.Activities.Game.Entity.Enemy.Commands
{
    public sealed class RandomJumpsMovingCommand : MonoCommand
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private PlayerView _playerView;

        [SerializeField] private float _jumpForce;
        [SerializeField] private float _angleOffset;
        [SerializeField] private float _timeBetweenJumps;

        private float _timer = 0f;

        private void Awake()
        {
            Assert.IsNotNull(_playerView, "[RandomJumpsMovingCommand] EnemyView is required");
            Assert.IsNotNull(_rigidbody, "[RandomJumpsMovingCommand] Rigidbody2D is required");
        }

        public override void Execute()
        {
            if (_timer > _timeBetweenJumps)
            {
                float randomAngle = Random.Range(0f, 2 * Mathf.PI);
                var randomDirection = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle));

                Jump(randomDirection);
                RotateEye(randomDirection);

                _timer = 0f;
            }
            else _timer += Time.deltaTime;
        }

        private void Jump(Vector3 direction)
        {
            _rigidbody.AddForce(_jumpForce * direction, ForceMode2D.Impulse);
        }

        private void RotateEye(Vector3 direction)
        {
            float z = Quaternion.FromToRotation(Vector3.right, direction).eulerAngles.z;
            _rigidbody.rotation = z - _angleOffset;
        }
    }
}
