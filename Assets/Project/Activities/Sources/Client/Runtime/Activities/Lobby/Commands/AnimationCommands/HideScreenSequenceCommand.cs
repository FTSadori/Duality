using Client.Runtime.Framework.Unity.SceneCommands;
using DG.Tweening;
using UnityEngine;

namespace Client.Runtime.Activities.Lobby.Commands.AnimationCommands
{
    public sealed class HideScreenSequenceCommand : SequenceCommand
    {
        [SerializeField] private RectTransform _screen;

        public override void Execute()
        {
            Sequence sequence = DOTween.Sequence();

            sequence.Insert(0f, _screen.DOAnchorPosY(0f, 0.2f).SetEase(Ease.InOutQuad));
            sequence.Insert(0.2f, _screen.DOAnchorPosY(500f, 0.7f).SetEase(Ease.OutQuad));
            
            sequence.OnComplete(() => { OnComplete?.Invoke(); });
        }
    }
}
