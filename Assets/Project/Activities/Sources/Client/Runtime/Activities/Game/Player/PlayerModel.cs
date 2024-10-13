using System;
using UnityEngine;

namespace Client.Runtime.Activities.Game.Player
{
    public sealed class PlayerModel
    {
        private int _maxHp = 5;
        private int _hp = 5;
        public event Action PlayerIsDead;

        public int MaxHp { get; }

        public int Hp
        {
            get => _hp;
            set
            {
                _hp = Mathf.Clamp(value, 0, _maxHp);
                if (_hp == 0)
                {
                    PlayerIsDead?.Invoke();
                }
            }
        }
    }
}
