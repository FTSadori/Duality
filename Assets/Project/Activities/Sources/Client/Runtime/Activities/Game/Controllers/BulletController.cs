using System;
using UnityEngine;

namespace Client.Runtime.Activities.Game.Controllers
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class BulletController : MonoBehaviour
    {
        public int ContactDamage => _contactDamage;
        public Action OnHit;
        public Action BeforeDestroy;

        [Header("Stats")]
        [SerializeField] private int _contactDamage = 1;
        public Vector2 _forceVector;

        [Header("Destroying")]
        [SerializeField] private bool _isDestroyableFromContact = false;
        [SerializeField] private float _timeToAutoDestroy = 5f;

        public Rigidbody2D Rb { get; private set; }

        private void Awake()
        {
            Rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _timeToAutoDestroy -= Time.deltaTime;

            if (_timeToAutoDestroy < 0)
                Destroy(gameObject);
        }

        public void AfterEnemyHit()
        {
            OnHit?.Invoke();

            if (_isDestroyableFromContact)
            {
                Destroy(gameObject);
            }
        }

        private void OnDestroy()
        {
            BeforeDestroy?.Invoke();
        }
    }
}
