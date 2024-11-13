using Client.Runtime.Framework.Unity.SceneCommands;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Client.Runtime.Activities.Game.Commands.AnimationCommands
{
    public sealed class ShowInventorySequenceCommand : SequenceCommand
    {
        [SerializeField] private RectTransform _wholeTopMenu;
        [SerializeField] private RectTransform _wholeBackButton;
        [SerializeField] private RectTransform _eye1;
        [SerializeField] private RectTransform _eye2;
        [SerializeField] private RectTransform _eye3;
        [SerializeField] private RectTransform _eye4;
        [SerializeField] private RectTransform _eye5;
        [SerializeField] private RectTransform _eye6;
        [SerializeField] private Image _backButtonImage;
        [SerializeField] private GameObject _backButton;
        [SerializeField] private TMP_Text _backButtonText;
        [SerializeField] private TMP_Text _innerTitle;
        [SerializeField] private TMP_Text _outerTitle;
        [SerializeField] private GameObject _closeButton;

        public override void Execute()
        {
            Sequence sequence = DOTween.Sequence();
            _backButton.SetActive(true);
            _closeButton.SetActive(false);

            sequence.Insert(0f, _wholeTopMenu.DOAnchorPosY(85f - 170f, 1f).SetEase(Ease.InOutQuad));
            sequence.Insert(0.5f, _eye1.DOAnchorPos(new Vector2(-300f, -150f), 1f).SetEase(Ease.OutQuad));
            sequence.Insert(0.6f, _eye2.DOAnchorPos(new Vector2(-180f, -100f), 1f).SetEase(Ease.OutQuad));
            sequence.Insert(0.7f, _eye3.DOAnchorPos(new Vector2(-60f, -76f), 1f).SetEase(Ease.OutQuad));
            sequence.Insert(0.8f, _eye4.DOAnchorPos(new Vector2(60f, -76f), 1f).SetEase(Ease.OutQuad));
            sequence.Insert(0.9f, _eye5.DOAnchorPos(new Vector2(180f, -100f), 1f).SetEase(Ease.OutQuad));
            sequence.Insert(1f, _eye6.DOAnchorPos(new Vector2(300f, -150f), 1f).SetEase(Ease.OutQuad));
            sequence.Insert(0f, _wholeBackButton.DORotate(new Vector3(0, 0, -180f), 0.3f).SetEase(Ease.OutQuad));
            sequence.Insert(0f, _backButtonImage.DOFade(1f, 0.3f).SetEase(Ease.OutQuad));
            sequence.Insert(0f, _wholeBackButton.DOAnchorPosY(-10f, 0.3f).SetEase(Ease.OutQuad));
            sequence.Insert(0f, _backButtonText.DOFade(1f, 0.3f).SetEase(Ease.OutQuad));
            sequence.Insert(0f, _innerTitle.DOFade(0f, 0.3f).SetEase(Ease.InQuad));
            sequence.Insert(0f, _outerTitle.DOFade(0f, 0.3f).SetEase(Ease.InQuad));

            sequence.OnComplete(() => { OnComplete?.Invoke(); });
        }
    }
}
