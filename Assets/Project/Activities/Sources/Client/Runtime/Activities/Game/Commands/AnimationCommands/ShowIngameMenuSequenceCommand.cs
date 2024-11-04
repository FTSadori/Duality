using Client.Runtime.Framework.Unity.SceneCommands;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Client.Runtime.Activities.Game.Commands.AnimationCommands
{
    public sealed class ShowIngameMenuSequenceCommand : SequenceCommand
    {
        [SerializeField] private GameObject _wholePopUp;
        [SerializeField] private RectTransform _topMenu;
        [SerializeField] private RectTransform _bottomMenu;
        [SerializeField] private RectTransform _eyesButton;
        [SerializeField] private RectTransform _resumeButton;
        [SerializeField] private RectTransform _settingsButton;
        [SerializeField] private RectTransform _restartButton;
        [SerializeField] private RectTransform _exitButton;
        [SerializeField] private Image _background;

        [SerializeField] private GameObject _closeCommand;

        public override void Execute()
        {
            _wholePopUp.SetActive(true);
            _closeCommand.SetActive(false);

            Sequence sequence = DOTween.Sequence();

            sequence.Insert(0f, _bottomMenu.DOAnchorPosX(0, 0.8f).SetEase(Ease.OutQuad));
            sequence.Insert(0.2f, _topMenu.DOAnchorPosX(0, 0.8f).SetEase(Ease.OutQuad));
            sequence.Insert(0f, _background.DOFade(0.4f, 0.4f));
            
            sequence.Insert(1f, _eyesButton.DOAnchorPosY(-50f, 0.4f).SetEase(Ease.OutQuad));
            sequence.Insert(0.8f, _resumeButton.DOAnchorPosY(100f, 0.4f).SetEase(Ease.OutQuad));
            sequence.Insert(1f, _settingsButton.DOAnchorPosY(100f, 0.4f).SetEase(Ease.OutQuad));
            sequence.Insert(1.2f, _restartButton.DOAnchorPosY(100f, 0.4f).SetEase(Ease.OutQuad));
            sequence.Insert(1.4f, _exitButton.DOAnchorPosY(100f, 0.4f).SetEase(Ease.OutQuad));

            sequence.OnComplete(() => {
                _closeCommand.SetActive(true);
                OnComplete?.Invoke(); 
            });
        }
    }
}
