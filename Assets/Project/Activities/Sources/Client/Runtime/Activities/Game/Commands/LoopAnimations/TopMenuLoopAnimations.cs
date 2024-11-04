using DG.Tweening;
using UnityEngine;

namespace Client.Runtime.Activities.Game.Commands.LoopAnimations
{
    public sealed class TopMenuLoopAnimations : MonoBehaviour
    {
        [SerializeField] private RectTransform _girl;
        [SerializeField] private RectTransform _outerSoul;
        [SerializeField] private RectTransform _outerTitle;
        [SerializeField] private RectTransform _outerDesc;
        [SerializeField] private RectTransform _innerSoul;
        [SerializeField] private RectTransform _innerTitle;
        [SerializeField] private RectTransform _innerDesc;

        Sequence sequence;

        private void Awake()
        {
            sequence = DOTween.Sequence();

            sequence.Insert(0f, _girl.DOAnchorPosY(20f, 10f).SetEase(Ease.InOutQuad).SetLoops(10000, LoopType.Yoyo));
            sequence.Insert(0f, _outerSoul.DOAnchorPosY(367f, 6f).SetEase(Ease.InOutQuad).SetLoops(10000, LoopType.Yoyo).SetDelay(3f));
            sequence.Insert(0f, _outerTitle.DOAnchorPosY(190f, 6f).SetEase(Ease.InOutQuad).SetLoops(10000, LoopType.Yoyo).SetDelay(3f));
            sequence.Insert(0f, _outerDesc.DOAnchorPosY(144f, 6f).SetEase(Ease.InOutQuad).SetLoops(10000, LoopType.Yoyo).SetDelay(3f));
            sequence.Insert(0f, _innerSoul.DOAnchorPosY(367f, 6f).SetEase(Ease.InOutQuad).SetLoops(10000, LoopType.Yoyo));
            sequence.Insert(0f, _innerTitle.DOAnchorPosY(190f, 6f).SetEase(Ease.InOutQuad).SetLoops(10000, LoopType.Yoyo));
            sequence.Insert(0f, _innerDesc.DOAnchorPosY(144f, 6f).SetEase(Ease.InOutQuad).SetLoops(10000, LoopType.Yoyo));
        }

        private void OnDestroy()
        {
            sequence.Kill();
        }
    }
}
