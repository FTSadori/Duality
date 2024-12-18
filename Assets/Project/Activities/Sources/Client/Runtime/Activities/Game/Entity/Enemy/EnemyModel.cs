﻿namespace Client.Runtime.Activities.Game.Entity.Enemy
{
    public sealed class EnemyModel : AbstractEntityModel
    {
        public bool CanSeePlayer { get; set; }

        public EnemyModel(int maxHp, float knockbackResist) 
        {
            _maxHp = maxHp;
            _hp = maxHp;
            _knockbackResistance = knockbackResist;
        }
    }
}
