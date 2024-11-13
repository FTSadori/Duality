using Client.Runtime.Framework.Unity.SceneCommands;
using DG.Tweening;
using UnityEngine;

namespace Client.Runtime.Activities.Lobby.Commands.AnimationCommands
{
    public sealed class HideLobbySequenceCommand : SequenceCommand
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

            sequence.Insert(0f, _buttonLeftTop.DOAnchorPosX(-362f, 0.6f).SetEase(Ease.OutQuad));
            sequence.Insert(0.1f, _buttonLeftDown.DOAnchorPosX(-340f, 0.6f).SetEase(Ease.OutQuad));
            sequence.Insert(0f, _buttonRightTop.DOAnchorPosX(362f, 0.6f).SetEase(Ease.OutQuad));
            sequence.Insert(0.1f, _buttonRightDown.DOAnchorPosX(340f, 0.6f).SetEase(Ease.OutQuad));
            sequence.Insert(0f, _logoImage.DOAnchorPosY(363f, 0.6f).SetEase(Ease.OutQuad));
            sequence.Insert(0.4f, _girlImage.DOAnchorPosY(110f, 0.1f).SetEase(Ease.OutQuad));
            sequence.Insert(0.5f, _girlImage.DOAnchorPosY(-404f, 0.6f).SetEase(Ease.OutQuad));

            sequence.OnComplete(() => { OnComplete?.Invoke(); });
        }
    }
}
