using Assets.Project.Activities.Sources.Client.Runtime.Activities.Game.Base;
using Client.Runtime.Activities.Game.Installers;
using PlayFab;
using PlayFab.ClientModels;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Client.Runtime.Activities.Game.Base
{
    public sealed class FinishLineController : MonoBehaviour
    {
        [Inject] PointsModel _points;
        [SerializeField] GameObject _window;
        [SerializeField] Transform _table;
        [SerializeField] TMPro.TMP_Text _ourResult;
        [SerializeField] TMPro.TMP_Text _errorMessage;
        [SerializeField] GameObject _player;

        [SerializeField] GameObject _rowPrefab;

        private List<GameObject> _rows = new();

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("PlayerEntity"))
            {
                GameOver();
            }
        }

        void GameOver()
        {
            _window.SetActive(true);
            _player.SetActive(false);
            var total = Mathf.Max(0, _points.score);

            _ourResult.text = "New final score:" + total.ToString();

            var request = new UpdatePlayerStatisticsRequest
            {
                Statistics = new List<StatisticUpdate>
                {
                    new StatisticUpdate
                    {
                        StatisticName = "TutorialScore",
                        Value = total,
                    }
                }
            };
            PlayFabClientAPI.UpdatePlayerStatistics(request, OnStatSuccess, OnError);
        }

        private void OnStatSuccess(UpdatePlayerStatisticsResult obj)
        {
            GetLeaderboard();
        }

        public void GetLeaderboard()
        {
            var request = new GetLeaderboardAroundPlayerRequest
            {
                StatisticName = "TutorialScore",
                MaxResultsCount = 7,
            };
            PlayFabClientAPI.GetLeaderboardAroundPlayer(request, OnSuccess, OnError);
        }

        private void OnSuccess(GetLeaderboardAroundPlayerResult result)
        {
            DrawLeaderBoard(result);
        }

        private void OnError(PlayFabError obj)
        {
            _errorMessage.text = obj.ErrorMessage;
        }

        private void DrawLeaderBoard(GetLeaderboardAroundPlayerResult result)
        {
            int y = 87;
            foreach (var item in result.Leaderboard)
            {
                GameObject newRow = Instantiate(_rowPrefab, _table);

                newRow.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, y);
                _rows.Add(newRow);
                y -= 30;

                var texts = newRow.GetComponentsInChildren<TMPro.TMP_Text>();
                texts[0].text = (item.Position + 1).ToString();
                texts[1].text = item.DisplayName;
                texts[2].text = item.StatValue.ToString();

                if (item.PlayFabId == PlayerStaticStats.PlayerID)
                {
                    texts[0].color = Color.red;
                    texts[1].color = Color.red;
                    texts[2].color = Color.red;
                }
            }
        }

        public void ClearLeaderboard()
        {
            foreach (var row in _rows)
            {
                Destroy(row);
            }
            _rows.Clear();
        }
    }
}
