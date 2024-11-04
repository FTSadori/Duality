using Client.Runtime.Framework.Unity.SceneCommands;
using DG.Tweening;
using UnityEngine;

namespace Client.Runtime.Activities.Game.Commands.AnimationCommands
{
    public sealed class ShowBottomMenuSequenceCommand : SequenceCommand
    {
        [SerializeField] private RectTransform _wholeBottomMenu;
        [SerializeField] private RectTransform _wholeMiddleMenu;

        public override void Execute()
        {
            Sequence sequence = DOTween.Sequence();

            sequence.Insert(0f, _wholeBottomMenu.DOAnchorPosY(0f, 1f).SetEase(Ease.InOutQuad));
            sequence.Insert(0f, _wholeMiddleMenu.DOAnchorPosY(450f, 1f).SetEase(Ease.InOutQuad));

            sequence.OnComplete(() => { OnComplete?.Invoke(); });
        }
    }
}
