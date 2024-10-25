using Client.Runtime.Framework.Unity.SceneCommands;
using DG.Tweening;
using UnityEngine;

namespace Client.Runtime.Activities.Lobby.Commands.AnimationCommands
{
    public sealed class HideSettingsSequenceCommand : SequenceCommand
    {
        [SerializeField] private GameObject _wholeMenu;
        [SerializeField] private Transform _settings;
        [SerializeField] private Transform _closeButton;

        public override void Execute()
        {
            Sequence sequence = DOTween.Sequence();

            sequence.Insert(0f, _settings.DOScale(new Vector3(0f, 0.4f, 1f), 0.6f));
            sequence.Insert(0f, _settings.DOShakeRotation(0.6f, new Vector3(0f, 0f, 15f), randomnessMode: ShakeRandomnessMode.Harmonic).SetEase(Ease.InQuad));
            sequence.Insert(0f, _closeButton.DOScale(new Vector3(0f, 0.3f, 1f), 0.6f));
            sequence.Insert(0f, _closeButton.DOShakeRotation(0.6f, new Vector3(0f, 0f, 30f), randomnessMode: ShakeRandomnessMode.Harmonic).SetEase(Ease.InQuad));

            sequence.OnComplete(() => {
                _wholeMenu.SetActive(false);
                OnComplete?.Invoke();
            });
        }
    }
}
