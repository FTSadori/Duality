using UnityEngine;

namespace Client.Runtime.Activities.BackgroundLobby
{
    public sealed class BackgroundLobbyController : MonoBehaviour
    {
        [SerializeField] private GameObject _bottomBackgroundImage;
        private float _timer = 0;
        private float _angleSpeed = 0.5f;

        private void Update()
        {
            _timer += Time.deltaTime;
            _bottomBackgroundImage.transform.localPosition = new Vector3(Mathf.Cos(_timer * _angleSpeed) * 30f, Mathf.Sin(_timer * _angleSpeed) * 30f, 0);
        }
    }
}
