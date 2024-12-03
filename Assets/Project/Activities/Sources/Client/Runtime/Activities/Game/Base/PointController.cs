using Client.Runtime.Activities.Game.Installers;
using Client.Runtime.Activities.Game.Player;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.Project.Activities.Sources.Client.Runtime.Activities.Game.Base
{
    public sealed class PointController : MonoBehaviour
    {
        [Inject] PointsModel _points;
        [SerializeField] TMPro.TMP_Text _score;

        [Inject] PlayerModel _playerModel;

        bool _isStopped = false;

        public int FinalPoints => Mathf.Max(_points.score, 0);

        private void Start()
        {
            StartCoroutine(nameof(Timer));
            _playerModel.OnGotHit += AfterPlayerGotHit;
        }

        void AfterPlayerGotHit()
        {
            _points.score -= 20;
            _score.text = _points.score.ToString();
        }

        IEnumerator Timer()
        {
            while (true)
            {
                _points.score = Mathf.Max(_points.score - 1, 0);
                _score.text = _points.score.ToString();
                yield return new WaitForSeconds(1);
            }
        }

        public void Stop()
        {
            if (_isStopped)
                return;
                
            _playerModel.OnGotHit -= AfterPlayerGotHit;
            StopCoroutine(nameof(Timer));
            _isStopped = true;
        }

        private void OnDestroy()
        {
            Stop();
        }
    }
}
