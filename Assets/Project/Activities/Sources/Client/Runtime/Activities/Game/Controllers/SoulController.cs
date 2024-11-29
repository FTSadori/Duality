using Client.Runtime.Activities.Game.Commands.ButtonCommands;
using Client.Runtime.Activities.Game.Player;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Client.Runtime.Activities.Game.Controllers
{
    public class SoulController : MonoBehaviour
    {
        [Inject] private readonly PlayerModel _playerModel;

        [SerializeField] private RectMask2D _mask;
        [SerializeField] private Animator _tomoe;

        [SerializeField] private RestartSequenceCommand _command;
        [SerializeField] private GameObject _wholeMenuButton;

        private void Start()
        {
            UpdateSoul();
            _playerModel.OnSoulChanged += UpdateSoul;
            _playerModel.OnDeath += SoulOnDeath;
            _playerModel.OnRealDeath += OnRealDeath;
        }

        private void Update()
        {
            if (_playerModel.CurrentHP == 0 && _playerModel.Soul < 0.01f)
                return;

            _playerModel.Soul += 0.001f;
        }

        private void UpdateSoul()
        {
            float percentage = _playerModel.Soul / _playerModel.MaxSoul;
            float size = (1f - percentage) * 60f;
            _mask.padding = new Vector4(0f, 0f, 0f, size + 5f);

            if (_playerModel.Soul == _playerModel.MaxSoul)
            {
                _tomoe.SetBool("IsCircling", true);
            }
            else
            {
                _tomoe.SetBool("IsCircling", false);
            }
        }

        private void SoulOnDeath()
        {
            _playerModel.Soul -= 0.5f;
        }

        private void OnRealDeath()
        {
            _wholeMenuButton.SetActive(false);

            var tween = transform.DOMoveX(0f, 1.55f);

            tween.OnComplete(() => { _command.Execute(); });
        }

        private void OnDestroy()
        {
            _playerModel.OnSoulChanged -= UpdateSoul;
            _playerModel.OnDeath -= SoulOnDeath;
            _playerModel.OnRealDeath -= OnRealDeath;
        }
    }
}
