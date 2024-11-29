using Client.Runtime.Activities.Game.Player;
using UnityEngine;
using Zenject;
using DG.Tweening;
using System.Collections.Generic;

namespace Client.Runtime.Activities.Game.Controllers
{
    public sealed class HpController : MonoBehaviour
    {
        [Inject] private readonly PlayerModel _playerModel;

        [SerializeField] private GameObject _hpBar;
        [SerializeField] private GameObject _hpPrefab;

        private List<Animator> _hpAnimators = new();

        private void Start()
        {
            for (int i = 0; i < _playerModel.MaxHP; ++i)
            {
                var obj = Instantiate(_hpPrefab, _hpBar.transform);
                if (obj.TryGetComponent(out RectTransform rectTransform))
                {
                    rectTransform.anchoredPosition = new Vector3(20f + i * 30f, 0f);
                    rectTransform.DOScale(0.8f, 0.8f).SetEase(Ease.InCubic).SetDelay(0.3f * i);
                }
                if (obj.TryGetComponent(out Animator animator))
                {
                    animator.SetBool("IsFlaming", true);
                    _hpAnimators.Add(animator);
                }
            }

            _playerModel.OnHPChanged += UpdateHp;
        }

        private void UpdateHp()
        {
            for (int i = 0; i < _playerModel.MaxHP; ++i)
            {
                _hpAnimators[i].SetBool("IsFlaming", (i < _playerModel.CurrentHP));
            }
        }

        private void OnDestroy()
        {
            _playerModel.OnHPChanged -= UpdateHp;
        }
    }
}
