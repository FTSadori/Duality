using Client.Runtime.Framework.Unity.SceneCommands;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Client.Runtime.Activities.Lobby.Commands.AnimationCommands
{
    public sealed class HideSavesSequenceCommand : SequenceCommand
    {
        [SerializeField] private GameObject _wholeMenu;
        [SerializeField] private Transform _save1;
        [SerializeField] private Transform _save2;
        [SerializeField] private Transform _save3;
        [SerializeField] private Transform _closeButton;
        [SerializeField] private Image _title;

        public override void Execute()
        {
            var height = Screen.height;

            Sequence sequence = DOTween.Sequence();
            sequence.Insert(0f, _save1.DOScale(new Vector3(0f, 0.3f, 0f), 0.6f));
            sequence.Insert(0f, _save1.DOShakeRotation(0.6f, new Vector3(0f, 0f, 15f), randomnessMode: ShakeRandomnessMode.Harmonic).SetEase(Ease.InQuad));
            sequence.Insert(0f, _save2.DOScale(new Vector3(0f, 0.3f, 0f), 0.6f));
            sequence.Insert(0f, _save2.DOShakeRotation(0.6f, new Vector3(0f, 0f, 15f), randomnessMode: ShakeRandomnessMode.Harmonic).SetEase(Ease.InQuad));
            sequence.Insert(0f, _save3.DOScale(new Vector3(0f, 0.3f, 0f), 0.6f));
            sequence.Insert(0f, _save3.DOShakeRotation(0.6f, new Vector3(0f, 0f, 15f), randomnessMode: ShakeRandomnessMode.Harmonic).SetEase(Ease.InQuad));
            sequence.Insert(0f, _closeButton.DOScale(new Vector3(0f, 0.3f, 0f), 0.6f));
            sequence.Insert(0f, _closeButton.DOShakeRotation(0.6f, new Vector3(0f, 0f, 30f), randomnessMode: ShakeRandomnessMode.Harmonic).SetEase(Ease.InQuad));
            sequence.Insert(0f, _title.DOFade(0f, 0.5f));

            sequence.OnComplete(() => { 
                _wholeMenu.SetActive(false); 
                OnComplete?.Invoke(); 
            });
        }
    }
}
