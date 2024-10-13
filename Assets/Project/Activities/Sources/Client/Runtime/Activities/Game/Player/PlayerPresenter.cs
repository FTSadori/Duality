
using Client.Runtime.Framework.Presenter;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace Client.Runtime.Activities.Game.Player
{
    public sealed class PlayerPresenter : MonoPresenter
    {
        [SerializeField] private PlayerView _playerView;

        [Inject] private readonly PlayerModel _playerModel;

        private void Awake()
        {
            Assert.IsNotNull(_playerView, "[PlayerPresenter] PlayerView is required");
        }
        public override void Enable()
        {
        }

        public override void Disable()
        {
        }
    }
}
