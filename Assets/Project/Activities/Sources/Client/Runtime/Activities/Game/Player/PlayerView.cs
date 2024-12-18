﻿using System;
using UnityEngine;
using UnityEngine.Assertions;
using DG.Tweening;

namespace Client.Runtime.Activities.Game.Player
{
    public sealed class PlayerView : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public Rigidbody2D Rigidbody => _rigidbody;

        public event Action<GameObject> OnGotHit;
        public event Action<GameObject> OnGotContact;

        public Vector3 FixedPosition => _rigidbody.position + Vector2.up;

        private void Awake()
        {
            Assert.IsNotNull(_rigidbody, "[PlayerView] Rigidbody is required");
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("EnemyBullet"))
                OnGotHit?.Invoke(collision.gameObject);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("EnemyEntity"))
                OnGotContact?.Invoke(collision.gameObject);
        }
    }
}
