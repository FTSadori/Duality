using UnityEngine;
using UnityEngine.Assertions;

namespace Client.Runtime.Activities.Game.Player
{
    public sealed class PlayerView : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;

        public Rigidbody2D Rigidbody => _rigidbody;

        private void Awake()
        {
            Assert.IsNotNull(_rigidbody, "[PlayerView] Rigidbody is required");
        }
    }
}
