using Client.Runtime.Activities.Game.Player;
using Client.Runtime.Framework.Unity;
using UnityEngine;
using UnityEngine.Assertions;

namespace Client.Runtime.Activities.Game.Entity.Enemy.Commands
{
    public sealed class ToPlayerMovingCommand : MonoCommand
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private PlayerView _playerView;

        [SerializeField] private float _velocity;
        [SerializeField] private float _angleOffset;

        private void Awake()
        {
            Assert.IsNotNull(_rigidbody, "[ToPlayerMovingCommand] Rigidbody2D is required");
            Assert.IsNotNull(_playerView, "[ToPlayerMovingCommand] PlayerView is required");
        }

        public override void Execute()
        {
            var toPlayer = (_playerView.FixedPosition - _rigidbody.transform.position).normalized;

            Move(toPlayer);
            RotateEye(toPlayer);
        }

        private void Move(Vector3 direction)
        {
            _rigidbody.position += Time.deltaTime * _velocity * new Vector2(direction.x, direction.y);
        }

        private void RotateEye(Vector3 direction)
        {
            float z = Quaternion.FromToRotation(Vector3.right, direction).eulerAngles.z;
            _rigidbody.rotation = z - _angleOffset;
        }
    }
}
