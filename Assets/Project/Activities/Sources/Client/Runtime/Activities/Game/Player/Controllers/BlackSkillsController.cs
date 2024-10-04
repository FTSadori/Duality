using Client.Runtime.Activities.Game.Player.Base;
using UnityEngine;
using Zenject;

namespace Client.Runtime.Activities.Game.Player.Controllers
{
    public sealed class BlackSkillsController : MonoBehaviour
    {
        [Inject] private readonly PlayerModel _playerModel;

        [SerializeField] private BasicAttackCommand _basicAttackCommand;

        private void Update()
        {
            _basicAttackCommand?.Execute();
        }
    }
}
