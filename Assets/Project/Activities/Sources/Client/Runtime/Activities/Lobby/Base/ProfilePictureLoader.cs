using Client.Runtime.Activities.Game.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Project.Activities.Sources.Client.Runtime.Activities.Lobby.Base
{
    public sealed class ProfilePictureLoader : MonoBehaviour
    {
        [SerializeField] private int _id;
        [SerializeField] private AccountSettingsScriptableObject _settings;
        [SerializeField] private Image _image;

        public int Id { get { return _id; } }
        public Sprite Sprite { get { return _settings.profilePictures[_id]; } }

        private void Start()
        {
            _image.sprite = _settings.profilePictures[_id];
        }
    }
}
