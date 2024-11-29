using Client.Runtime.Activities.Game.Player;
using DG.Tweening;
using System;
using UnityEngine;
using Zenject;

namespace Client.Runtime.Activities.Game.Controllers
{
    public sealed class PlayerDeathController : MonoBehaviour
    {
        [Inject] private readonly PlayerModel _playerModel;

        [SerializeField] private Transform _playerTransform;
        [SerializeField] private SpriteRenderer _playerSprite;

        private void Start()
        {
            _playerModel.OnRealDeath += OnRealDeath;
        }
        private void OnRealDeath()
        {
            _playerTransform.DOShakePosition(1.5f, 0.5f, randomnessMode: ShakeRandomnessMode.Harmonic).SetEase(Ease.InQuad);
            _playerSprite.DOFade(0.3f, 1.5f);
        }

        private void OnDestroy()
        {
            _playerModel.OnRealDeath -= OnRealDeath;
        }
    }
}
