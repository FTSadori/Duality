using Client.Runtime.Activities.Game.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace Client.Runtime.Activities.Lobby.Base
{
    public sealed class ProfileColourLoader : MonoBehaviour
    {
        [SerializeField] private int _id;
        [SerializeField] private AccountSettingsScriptableObject _settings;
        [SerializeField] private Image _image;

        public int Id { get { return _id; } }
        public Color Color { get { return _settings.profileColors[_id]; } }

        private void Start()
        {
            _image.color = _settings.profileColors[_id];
        }
    }
}
