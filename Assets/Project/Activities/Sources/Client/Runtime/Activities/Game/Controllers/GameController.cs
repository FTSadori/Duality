using Client.Runtime.Activities.Game.Player;
using UnityEngine;
using UnityEngine.Assertions;

namespace Client.Runtime.Activities.Game.Controllers
{
    public sealed class GameController : MonoBehaviour
    {
        [SerializeField] private PlayerPresenter _playerPresenter;

        private void Awake()
        {
            Assert.IsNotNull(_playerPresenter, "[GameController] PlayerPresenter is required");
        }

        private void Start()
        {
            _playerPresenter.Enable();
        }

        private void OnDestroy()
        {
            _playerPresenter.Disable();
        }
    }
}
