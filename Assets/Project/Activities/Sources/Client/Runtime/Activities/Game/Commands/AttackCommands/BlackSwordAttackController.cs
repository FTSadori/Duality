using Client.Runtime.Activities.Game.Controllers;
using Client.Runtime.Activities.Game.Player;
using Client.Runtime.Activities.Game.Player.Base;
using Client.Runtime.Framework.Unity;
using UnityEngine;
using UnityEngine.Assertions;

namespace Client.Runtime.Activities.Game.Commands.AttackCommands
{
    public sealed class BlackSwordAttackController : BasicAttackCommand
    {
        [Header("Links")]
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private CursorController _cursorController;
        [SerializeField] private GameObject _swordPrefab;

        [Header("Values")]
        [SerializeField] private float _distanceToSword = 0.25f;
        [SerializeField] private float _swordAmplitude;
        [SerializeField] private float _swordRotationSpeed = 30f;
        [SerializeField] private float _swordPositionNormalize = 0.2f;

        private GameObject _currentSword = null;
        private float _currentSwordTargetAngle;
        private float _swordDirection = 1f;

        private void Awake()
        {
            Assert.IsNotNull(_playerView, "[BlackSwordAttackController] PlayerView is required");
            Assert.IsNotNull(_cursorController, "[BlackSwordAttackController] CursorController is required");
            Assert.IsNotNull(_swordPrefab, "[BlackSwordAttackController] SwordPrefab is required");
        }

        public override void Execute()
        {
            if (Input.GetMouseButtonDown(0) && _currentSword == null)
            {
                CreateSword();
            }
            else if (_currentSword != null)
            {
                AnimateSword();
            }
        }

        private void CreateSword()
        {
            Vector3 startPosition = _playerView.Rigidbody.position + new Vector2(0, 1f);
            _swordDirection *= -1f;
            _currentSword = Instantiate(
                _swordPrefab,
                startPosition + _distanceToSword * _cursorController.CursorDirection,
                Quaternion.Euler(0, 0, _cursorController.CursorAngle + _swordDirection * _swordAmplitude - 90f)
                );
            _currentSwordTargetAngle = 2f * _swordAmplitude;
            //_currentSword.GetComponent<BulletController>().SetOwner(gameObject);
        }

        private void AnimateSword()
        {
            Vector3 startPosition = _playerView.Rigidbody.position + new Vector2(0, 1f);
            _currentSword.transform.position = startPosition +
                _distanceToSword * _cursorController.CursorDirection + 
                _swordPositionNormalize * new Vector3(Input.GetAxis("Horizontal"), 0, 0);

            _currentSwordTargetAngle -= _swordRotationSpeed * Time.deltaTime;
            _currentSword.transform.rotation = Quaternion.Euler(0, 0,
                _currentSword.transform.rotation.eulerAngles.z - _swordDirection * _swordRotationSpeed * Time.deltaTime
                );

            if (_currentSwordTargetAngle < 0f)
            {
                Destroy(_currentSword);
            }
        }
    }
}
