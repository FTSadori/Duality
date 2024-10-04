using UnityEngine;
using UnityEngine.Assertions;

namespace Client.Runtime.Activities.Game.Player.Controllers
{
    public sealed class MovePlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private float _baseSpeed = 4f;

        private void Awake()
        {
            Assert.IsNotNull(_playerView, "[MovePlayerController] PlayerView is required");
        }

        private void FixedUpdate()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector2 normalized = new Vector2(horizontal, vertical).normalized;

            Moving(normalized);
        }

        private void Moving(Vector2 normalized)
        {
            _playerView.Rigidbody.position += Time.fixedDeltaTime * _baseSpeed * normalized;
        }
    }
}
