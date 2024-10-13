using UnityEngine;
using UnityEngine.Assertions;

namespace Client.Runtime.Activities.Game.Player.Controllers
{
    public sealed class PlayerSpriteTiltController : MonoBehaviour
    {
        [SerializeField] private PlayerView _playerView;

        [SerializeField] private float _baseHorizontalTilt = 10f;
        [SerializeField] private float _horizonalTiltSpeed = 4f;

        private float _currentTilt = 0f;

        private void Awake()
        {
            Assert.IsNotNull(_playerView, "[PlayerSpriteTiltController] PlayerView is required");
        }

        void FixedUpdate()
        {
            HorizontalTilting();
        }

        private void HorizontalTilting()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");

            if (horizontal != 0f)
            {
                _currentTilt += horizontal * _horizonalTiltSpeed;
                _currentTilt = Mathf.Clamp(_currentTilt, -_baseHorizontalTilt, _baseHorizontalTilt);
            }
            else if (_currentTilt != 0f)
            {
                float signWas = Mathf.Sign(_currentTilt);
                _currentTilt -= signWas * _horizonalTiltSpeed;
                if (Mathf.Sign(_currentTilt) != signWas)
                    _currentTilt = 0f;
            }

            _playerView.Rigidbody.rotation = -_currentTilt;
        }
    }
}
