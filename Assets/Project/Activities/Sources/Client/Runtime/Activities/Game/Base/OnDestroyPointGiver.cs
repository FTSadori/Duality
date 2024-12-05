using Client.Runtime.Activities.Game.Installers;
using UnityEngine;
using Zenject;

namespace Client.Runtime.Activities.Game.Base
{
    public sealed class OnDestroyPointGiver : MonoBehaviour
    {
        [Inject] PointsModel _points;
        [SerializeField] private int _bonus;

        private void OnDestroy()
        {
            if (_points != null)
            {
                _points.score += _bonus;
            }
        }
    }
}
