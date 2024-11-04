using Client.Runtime.Framework.Unity.SceneCommands;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Client.Runtime.Activities.Game.Commands.AnimationCommands
{
    public sealed class HideIngameMenuSequenceCommand : SequenceCommand
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

        public override void Execute()
        {
            Sequence sequence = DOTween.Sequence();

            sequence.Insert(0f, _eyesButton.DOAnchorPosY(50f, 0.4f).SetEase(Ease.InQuad));
            sequence.Insert(0.1f, _resumeButton.DOAnchorPosY(-100f, 0.4f).SetEase(Ease.InQuad));
            sequence.Insert(0.2f, _settingsButton.DOAnchorPosY(-100f, 0.4f).SetEase(Ease.InQuad));
            sequence.Insert(0.3f, _restartButton.DOAnchorPosY(-100f, 0.4f).SetEase(Ease.InQuad));
            sequence.Insert(0.4f, _exitButton.DOAnchorPosY(-100f, 0.4f).SetEase(Ease.InQuad));
            sequence.Insert(0f, _background.DOFade(0f, 0.4f));

            sequence.Insert(0.5f, _bottomMenu.DOAnchorPosX(-1500, 0.4f).SetEase(Ease.InQuad));
            sequence.Insert(0.5f, _topMenu.DOAnchorPosX(-1500, 0.4f).SetEase(Ease.InQuad));

            sequence.OnComplete(() => {
                _wholePopUp.SetActive(false);
                OnComplete?.Invoke();
            });
        }
    }
}
