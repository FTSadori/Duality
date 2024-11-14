using Client.Runtime.Activities.Game.ScriptableObjects;
using System;
using UnityEngine;

namespace Client.Runtime.Activities.Game.Controllers
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class BulletController : MonoBehaviour
    {
        public Action OnHit;
        public Action BeforeDestroy;

        [HideInInspector] public BulletScriptableObject _bulletScriptableObject;
        private float _timer = 0;

        [HideInInspector] public Vector2 _forceVector;

        public Rigidbody2D Rb { get; private set; }

        private void Awake()
        {
            Rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _timer += Time.deltaTime;

            if (_timer > _bulletScriptableObject._timeToAutoDestroy)
                Destroy(gameObject);
        }

        public void AfterEnemyHit()
        {
            OnHit?.Invoke();

            if (_bulletScriptableObject._isDestroyableFromContact)
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
