using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace Client.Runtime.Activities.Game.Player
{
    public sealed class PlayerView : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;

        public Rigidbody2D Rigidbody => _rigidbody;

        public event Action<GameObject> OnGotHit;

        private void Awake()
        {
            Assert.IsNotNull(_rigidbody, "[PlayerView] Rigidbody is required");
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("EnemyBullet"))
                OnGotHit?.Invoke(collision.gameObject);
        }
    }
}
