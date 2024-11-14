using System.Collections;
using UnityEngine;

namespace Client.Runtime.Activities.BackgroundLobby
{
    public sealed class BackgroundLobbyController : MonoBehaviour
    {
        [SerializeField] private GameObject _bottomBackgroundImage;

        private void Awake()
        {
            StartCoroutine(nameof(BottomBackgroundCircleMoving));
        }

        private IEnumerator BottomBackgroundCircleMoving()
        {
            float timer = 0;
            float angleSpeed = 0.5f;

            while (true)
            {
                timer += Time.deltaTime;
                _bottomBackgroundImage.transform.localPosition = new Vector3(Mathf.Cos(timer * angleSpeed) * 30f, Mathf.Sin(timer * angleSpeed) * 30f, 0);
                yield return null;
            }
        }

        private void OnDestroy()
        {
            StopCoroutine(nameof(BottomBackgroundCircleMoving));
        }
    }
}
