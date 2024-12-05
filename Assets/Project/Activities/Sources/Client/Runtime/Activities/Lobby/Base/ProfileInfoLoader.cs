using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Client.Runtime.Activities.Game.ScriptableObjects;

namespace Client.Runtime.Activities.Lobby.Base
{
    public sealed class ProfileInfoLoader : MonoBehaviour
    {
        [SerializeField] ProfileSettingsData _profileSettingsData;
        [SerializeField] AccountSettingsScriptableObject _settings;
        [SerializeField] Image _mini_icon;
        [SerializeField] TMP_Text _mini_name;
        [SerializeField] Image _icon;
        [SerializeField] TMP_Text _name;
        [SerializeField] TMP_InputField _description;

        public void LoadInfo(string name, string description, int colour_id, int profile_id)
        {
            _profileSettingsData._ColourId = colour_id;
            _profileSettingsData._PPId = profile_id;
            Sprite sprite = _settings.profilePictures[profile_id];
            Color color = _settings.profileColors[colour_id];
            _mini_icon.sprite = sprite;
            _mini_icon.color = color;
            _icon.sprite = sprite;
            _icon.color = color;
            _name.text = name;
            _mini_name.text = name;
            _description.text = description;
        }
    }
}
