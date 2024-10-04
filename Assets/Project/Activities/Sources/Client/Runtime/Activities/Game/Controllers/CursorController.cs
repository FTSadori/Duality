﻿using Client.Runtime.Activities.Game.Player;
using UnityEngine;
using UnityEngine.Assertions;

namespace Client.Runtime.Activities.Game.Controllers
{
    public sealed class CursorController : MonoBehaviour
    {
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private GameObject _cursorObject;
        [SerializeField] private float _distanceFromPlayer;

        private Vector2 _cursorDirection;
        private float _cursorAngle;

        public Vector3 CursorDirection => _cursorDirection;
        public float CursorAngle => _cursorAngle;

        private void Awake()
        {
            Assert.IsNotNull(_playerView, "[CursorController] PlayerView is required");
            Assert.IsNotNull(_cursorObject, "[CursorController] CursorObject is required");
        }

        private void Update()
        {
            UpdateCursorPosition();
        }

        private void UpdateCursorPosition()
        {
            var resolution = Screen.currentResolution;
            _cursorDirection = new Vector2(Input.mousePosition.x - resolution.width / 2, Input.mousePosition.y - resolution.height / 2).normalized;

            _cursorAngle = Mathf.Asin(_cursorDirection.y) * 180f / Mathf.PI;
            if (Mathf.Sign(_cursorDirection.x) == -1f)
                _cursorAngle = 180f - _cursorAngle;

            _cursorObject.transform.position = _playerView.Rigidbody.position + _distanceFromPlayer * _cursorDirection;
            _cursorObject.transform.position += new Vector3(0f, 1f);
        }
    }
}