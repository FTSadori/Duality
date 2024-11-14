using UnityEngine;

namespace Client.Runtime.Activities.Game.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Bullet", menuName = "ScriptableObjects/Bullet")]
    public class BulletScriptableObject : ScriptableObject
    {
        public int _contactDamage;
        public float _force;
        public float _speed;
        public bool _isDestroyableFromContact;
        public float _timeToAutoDestroy;
        public float _baseScale;
        public Color _color;
    }
}
