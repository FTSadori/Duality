using Client.Runtime.Activities.Game.Entity;
using System;
using UnityEngine;

namespace Client.Runtime.Activities.Game.Player
{
    public sealed class PlayerModel : AbstractEntityModel
    {
        public Action OnSoulChanged;
        public Action OnMaxSoulChanged;

        private float _maxSoul;
        private float _soul;

        public float MaxSoul
        {
            get => _maxSoul;
            set 
            { 
                _maxSoul = Mathf.Max(0f, value);
                Soul = _soul;
                OnMaxSoulChanged?.Invoke();
            }
        }

        public float Soul
        {
            get => _soul;
            set
            {
                _soul = Mathf.Clamp(value, 0f, _maxSoul);
                OnSoulChanged?.Invoke();
            }
        }

        private float _baseSpeed = 4f;

        public float Speed
        {
            get => _baseSpeed;
            set => _baseSpeed = Mathf.Max(0f, value);
        }
    }
}
