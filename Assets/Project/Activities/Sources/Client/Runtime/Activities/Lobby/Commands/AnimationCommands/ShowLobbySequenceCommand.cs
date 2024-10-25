using Client.Runtime.Framework.Unity.SceneCommands;
using DG.Tweening;
using UnityEngine;

namespace Client.Runtime.Activities.Lobby.Commands.AnimationCommands
{
    public sealed class ShowLobbySequenceCommand : SequenceCommand
    {
        [SerializeField] private RectTransform _girlImage;
        [SerializeField] private RectTransform _buttonLeftTop;
        [SerializeField] private RectTransform _buttonLeftDown;
        [SerializeField] private RectTransform _buttonRightTop;
        [SerializeField] private RectTransform _buttonRightDown;
        [SerializeField] private RectTransform _logoImage;

        public override void Execute()
        {
            Sequence sequence = DOTween.Sequence();

            sequence.Insert(0f, _buttonLeftTop.DOAnchorPosX(-262f, 1f).SetEase(Ease.OutQuad));
            sequence.Insert(0.2f, _buttonLeftDown.DOAnchorPosX(-241f, 1f).SetEase(Ease.OutQuad));
            sequence.Insert(0f, _buttonRightTop.DOAnchorPosX(262f, 1f).SetEase(Ease.OutQuad));
            sequence.Insert(0.2f, _buttonRightDown.DOAnchorPosX(241f, 1f).SetEase(Ease.OutQuad));
            sequence.Insert(0f, _logoImage.DOAnchorPosY(138f, 0.6f).SetEase(Ease.OutQuad));
            sequence.Insert(0.5f, _girlImage.DOAnchorPosY(110f, 1f).SetEase(Ease.OutQuad));
            sequence.Insert(1.5f, _girlImage.DOAnchorPosY(87f, 0.2f).SetEase(Ease.InQuad));
            
            sequence.OnComplete(() => { OnComplete?.Invoke(); });
        }
    }
}
