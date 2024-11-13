using Client.Runtime.Framework.Unity.SceneCommands;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Client.Runtime.Activities.Game.Commands.AnimationCommands
{
    public sealed class HideInventorySequenceCommand : SequenceCommand
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

            sequence.Insert(0.5f, _wholeTopMenu.DOAnchorPosY(85f, 1f).SetEase(Ease.InOutQuad));
            sequence.Insert(0.0f, _eye1.DOAnchorPos(new Vector2(0f, 150f), 1f).SetEase(Ease.OutQuad));
            sequence.Insert(0.1f, _eye2.DOAnchorPos(new Vector2(0f, 150f), 1f).SetEase(Ease.OutQuad));
            sequence.Insert(0.2f, _eye3.DOAnchorPos(new Vector2(0f, 150f), 1f).SetEase(Ease.OutQuad));
            sequence.Insert(0.3f, _eye4.DOAnchorPos(new Vector2(0f, 150f), 1f).SetEase(Ease.OutQuad));
            sequence.Insert(0.4f, _eye5.DOAnchorPos(new Vector2(0f, 150f), 1f).SetEase(Ease.OutQuad));
            sequence.Insert(0.5f, _eye6.DOAnchorPos(new Vector2(0f, 150f), 1f).SetEase(Ease.OutQuad));
            sequence.Insert(0.0f, _wholeBackButton.DORotate(new Vector3(0, 0, 0), 0.3f).SetEase(Ease.OutQuad));
            sequence.Insert(0.0f, _backButtonImage.DOFade(0f, 0.3f).SetEase(Ease.OutQuad));
            sequence.Insert(0.0f, _backButtonText.DOFade(0f, 0.3f).SetEase(Ease.OutQuad));
            sequence.Insert(0.0f, _wholeBackButton.DOAnchorPosY(-60f, 0.3f).SetEase(Ease.OutQuad));
            sequence.Insert(0.5f, _innerTitle.DOFade(1f, 0.3f).SetEase(Ease.InQuad));
            sequence.Insert(0.5f, _outerTitle.DOFade(1f, 0.3f).SetEase(Ease.InQuad));

            sequence.OnComplete(() => {
                _backButton.SetActive(false);
                _closeButton.SetActive(true);
                OnComplete?.Invoke(); 
            });
        }
    }
}
