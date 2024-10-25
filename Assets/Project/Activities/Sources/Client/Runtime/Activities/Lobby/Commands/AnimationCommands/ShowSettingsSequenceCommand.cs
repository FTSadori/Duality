using Client.Runtime.Framework.Unity.SceneCommands;
using DG.Tweening;
using UnityEngine;

namespace Client.Runtime.Activities.Lobby.Commands.AnimationCommands
{
    public sealed class ShowSettingsSequenceCommand : SequenceCommand
    {
        [SerializeField] private GameObject _wholeMenu;
        [SerializeField] private Transform _settings;
        [SerializeField] private Transform _closeButton;

        public override void Execute()
        {
            _wholeMenu.SetActive(true);

            Sequence sequence = DOTween.Sequence();
            sequence.Insert(0f, _settings.DORotate(new Vector3(0f, 0f, 0f), 0f));
            sequence.Insert(0f, _settings.DOScale(new Vector3(0f, 0.3f, 1f), 0f));
            sequence.Insert(0f, _closeButton.DORotate(new Vector3(0f, 0f, 0f), 0f));
            sequence.Insert(0f, _closeButton.DOScale(new Vector3(0f, 0.3f, 1f), 0f));

            sequence.Insert(0f, _settings.DOScale(new Vector3(1f, 1f, 1f), 1.2f));
            sequence.Insert(0f, _settings.DOShakeRotation(1.2f, new Vector3(0f, 0f, 15f), randomnessMode: ShakeRandomnessMode.Harmonic).SetEase(Ease.InQuad));
            sequence.Insert(0f, _closeButton.DOScale(new Vector3(1f, 1f, 1f), 1.2f));
            sequence.Insert(0f, _closeButton.DOShakeRotation(1.2f, new Vector3(0f, 0f, 30f), randomnessMode: ShakeRandomnessMode.Harmonic).SetEase(Ease.InQuad));

            sequence.OnComplete(() => { OnComplete?.Invoke(); });
        }
    }
}
