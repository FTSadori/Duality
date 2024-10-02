using Client.Runtime.Framework.Unity.TransitionBehaviors;
using Codice.Client.Common.GameUI;
using UnityEngine;
using UnityEngine.UI;

namespace Client.Runtime.Activities.Lobby.Transitions
{
    public sealed class LobbyUnloadTransition : TransitionBehavior
    {
        [SerializeField] private Image _characterImage;

        private Vector3 _charStartPosition;
        private Vector3 _charTopPosition;
        private Vector3 _charBottomPosition;
        private float _charJumpTime = 0.5f;
        private float _charDownTime = 0.7f;

        private float _timer = 0;

        private void Awake()
        {
            _charStartPosition = _characterImage.transform.localPosition;
            _charTopPosition = _charStartPosition;
            _charTopPosition.y += _characterImage.flexibleHeight / 6f;
            _charBottomPosition = _charTopPosition;
            _charTopPosition.y -= _characterImage.flexibleHeight * 1.2f;
        }

        public override bool Transition()
        {
            bool ret = true;

            if (_timer < _charJumpTime)
            {
                _characterImage.transform.localPosition = Vector3.Lerp(
                    _charStartPosition, 
                    _charTopPosition, 
                    _timer / _charJumpTime
                );
                ret = false;
            }
            else if (_timer - _charJumpTime < _charDownTime)
            {
                _characterImage.transform.localPosition = Vector3.Lerp(
                    _charTopPosition,
                    _charBottomPosition,
                    (_timer - _charJumpTime) / _charDownTime
                );
                ret = false;
            }

            _timer += Time.deltaTime;
            return ret;
        }
    }
}
