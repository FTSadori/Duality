using Client.Runtime.Framework.Unity.SceneCommands;
using DG.Tweening;
using UnityEngine;

namespace Client.Runtime.Activities.Lobby.Commands.AnimationCommands.SettingsAnimations
{
    public sealed class OpenVideoMenuSequenceCommand : SequenceCommand
    {
        [SerializeField] private RectTransform _scissors;
        [SerializeField] private RectTransform _audioMenu;
        [SerializeField] private RectTransform _videoMenu;
        [SerializeField] private RectTransform _controlsMenu;

        public override void Execute()
        {
            Sequence sequence = DOTween.Sequence();

            sequence.Insert(0f, _scissors.DOAnchorPosX(263f, 0.3f).SetEase(Ease.InOutQuad));
            sequence.Insert(0f, _controlsMenu.DOScaleY(0f, 0.3f).SetEase(Ease.InOutQuad));
            sequence.Insert(0f, _audioMenu.DOScaleY(0f, 0.3f).SetEase(Ease.InOutQuad));
            sequence.Insert(0.3f, _videoMenu.DOScaleY(1f, 0.3f).SetEase(Ease.InOutQuad));

            sequence.OnComplete(() => { OnComplete?.Invoke(); });
        }
    }
}
