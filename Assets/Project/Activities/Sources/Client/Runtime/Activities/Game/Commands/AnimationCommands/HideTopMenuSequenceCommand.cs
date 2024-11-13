﻿using Client.Runtime.Framework.Unity.SceneCommands;
using DG.Tweening;
using UnityEngine;

namespace Client.Runtime.Activities.Game.Commands.AnimationCommands
{
    public sealed class HideTopMenuSequenceCommand : SequenceCommand
    {
        [SerializeField] private RectTransform _wholeTopMenu;
        [SerializeField] private RectTransform _wholeMiddleMenu;
        
        public override void Execute()
        {
            Sequence sequence = DOTween.Sequence();

            sequence.Insert(0f, _wholeTopMenu.DOAnchorPosY(800f + 85f, 0.6f).SetEase(Ease.InOutQuad));
            sequence.Insert(0f, _wholeMiddleMenu.DOAnchorPosY(0f, 0.6f).SetEase(Ease.InOutQuad));

            sequence.OnComplete(() => { OnComplete?.Invoke(); });
        }
    }
}
