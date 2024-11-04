using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace Client.Runtime.Activities.Game.Entity.Enemy
{
    public sealed class EnemyView : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private int _contactDamage;

        public Rigidbody2D Rigidbody => _rigidbody;
        public int ContactDamage => _contactDamage;

        private void Awake()
        {
            Assert.IsNotNull(_rigidbody, "[EnemyView] Rigidbody is required");
        }

        public event Action<GameObject> OnGotHit;
        public event Action OnFindPlayer;
        public event Action OnLosePlayer;

        public void WhenFindPlayer()
        {
            OnFindPlayer?.Invoke();
        }

        public void WhenLosePlayer()
        {
            OnLosePlayer?.Invoke();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("PlayerBullet"))
                OnGotHit?.Invoke(collision.gameObject);
        }
    }
}
