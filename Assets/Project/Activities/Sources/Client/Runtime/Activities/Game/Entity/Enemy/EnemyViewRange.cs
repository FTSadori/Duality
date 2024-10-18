using UnityEngine;
using UnityEngine.Assertions;

namespace Client.Runtime.Activities.Game.Entity.Enemy
{
    public sealed class EnemyViewRange : MonoBehaviour
    {
        [SerializeField] private EnemyView _enemyView;

        private void Awake()
        {
            Assert.IsNotNull(_enemyView, "[EnemyViewRange] EnemyView is required");
        }

        private void Update()
        {
            transform.position = _enemyView.Rigidbody.position;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("PlayerEntity"))
            {
                _enemyView.WhenFindPlayer();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("PlayerEntity"))
            {
                _enemyView.WhenLosePlayer();
            }

        }
    }
}
