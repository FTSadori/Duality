using Client.Runtime.Framework.Unity.SceneCommands;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Client.Runtime.Activities.Lobby.Commands.AnimationCommands
{
    public sealed class ShowSmallPopUpCommand : SequenceCommand
    {
        [SerializeField] private GameObject _wholePopUp;
        [SerializeField] private Transform _popUp;
        [SerializeField] private Image _background;

        public override void Execute()
        {
            _wholePopUp.SetActive(true);

            Sequence sequence = DOTween.Sequence();
            sequence.Insert(0f, _popUp.DORotate(new Vector3(0f, 0f, 0f), 0f));
            sequence.Insert(0f, _background.DOFade(0.0f, 0f));
            sequence.Insert(0f, _popUp.DOScale(new Vector3(0f, 0.6f, 1f), 0f));
            sequence.Insert(0f, _background.DOFade(0.6f, 1.2f));
            sequence.Insert(0f, _popUp.DOScale(new Vector3(1f, 1f, 1f), 1.2f));
            sequence.Insert(0f, _popUp.DOShakeRotation(1.2f, new Vector3(0f, 0f, 25f), randomnessMode: ShakeRandomnessMode.Harmonic).SetEase(Ease.InQuad));

            sequence.OnComplete(() => { OnComplete?.Invoke(); });
        }
    }
}
