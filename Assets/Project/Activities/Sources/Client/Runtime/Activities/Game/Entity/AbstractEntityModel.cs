using System;
using UnityEngine;

namespace Client.Runtime.Activities.Game.Entity
{
    public abstract class AbstractEntityModel
    {
        protected int _maxHp = 5;
        protected int _hp = 5;
        protected float _knockbackResistance = 0f;

        public event Action OnHPChanged;
        public event Action OnGotHit;
        public event Action OnGotHeal;
        public event Action OnDeath;

        public int MaxHP
        {
            get => _maxHp;
            set => _maxHp = Mathf.Max(value, 1);
        }

        public int CurrentHP
        {
            get => _hp;
            set
            {
                int oldHp = _hp;
                value = Mathf.Clamp(value, 0, _maxHp);
                _hp = value;
                OnHPChanged?.Invoke();

                if (value > oldHp)
                {
                    OnGotHeal?.Invoke();
                }
                else if (value == 0)
                {
                    OnDeath?.Invoke();
                }
                else if (value < oldHp)
                {
                    OnGotHit?.Invoke();
                }
            }
        }

        public float KnockbackResistance
        {
            get => _knockbackResistance;
            set => _knockbackResistance = Mathf.Clamp(value, -1f, 1f);
        }
    }
}
