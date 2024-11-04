using Client.Runtime.Framework.Unity.SceneCommands;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Client.Runtime.Activities.Lobby.Commands.AnimationCommands
{
    public sealed class CloseSmallPopUpCommand : SequenceCommand
    {
        [SerializeField] private GameObject _wholePopUp;
        [SerializeField] private Transform _popUp;
        [SerializeField] private Image _background;

        public override void Execute()
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Insert(0f, _background.DOFade(0.0f, 1f));
            sequence.Insert(0f, _popUp.DOScale(new Vector3(0f, 0.6f, 1f), 1f));
            sequence.Insert(0f, _popUp.DOShakeRotation(1f, new Vector3(0f, 0f, 25f), randomnessMode: ShakeRandomnessMode.Harmonic).SetEase(Ease.InQuad));

            sequence.OnComplete(() => {
                _wholePopUp.SetActive(false);
                OnComplete?.Invoke(); 
            });
        }
    }
}
