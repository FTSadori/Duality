using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace Client.Runtime.Activities.Game.Player.Controllers
{
    public sealed class MovePlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerView _playerView;
        [Inject] private PlayerModel _playerModel;

        private void Awake()
        {
            Assert.IsNotNull(_playerView, "[MovePlayerController] PlayerView is required");
        }

        private void FixedUpdate()
        {
            if (_playerModel.CurrentHP == 0 && _playerModel.Soul < 0.01f)
                return;


            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector2 normalized = new Vector2(horizontal, vertical).normalized;

            Moving(normalized);
        }

        private void Moving(Vector2 normalized)
        {
            _playerView.Rigidbody.position += Time.fixedDeltaTime * _playerModel.Speed * normalized;
        }
    }
}
