using Client.Runtime.Framework.Unity.SceneCommands;
using DG.Tweening;
using UnityEngine;

namespace Client.Runtime.Activities.Lobby.Commands.AnimationCommands
{
    public sealed class ShowScreenSequenceCommand : SequenceCommand
    {
        [SerializeField] private RectTransform _screen;

        public override void Execute()
        {
            Sequence sequence = DOTween.Sequence();

            sequence.Insert(0f, _screen.DOAnchorPosY(0f, 0.7f).SetEase(Ease.InQuad));
            sequence.Insert(0.7f, _screen.DOAnchorPosY(50f, 0.2f).SetEase(Ease.InOutQuad));
            
            sequence.OnComplete(() => { OnComplete?.Invoke(); });
        }
    }
}
