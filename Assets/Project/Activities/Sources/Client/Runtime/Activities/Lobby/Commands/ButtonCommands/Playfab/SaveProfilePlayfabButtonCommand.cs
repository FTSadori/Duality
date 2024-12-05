using Client.Runtime.Framework.Unity;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Client.Runtime.Activities.Lobby.Base;
using Client.Runtime.Activities.Game.ScriptableObjects;
using Client.Runtime.Activities.Game.Base;

namespace Client.Runtime.Activities.Lobby.Commands.ButtonCommands.Playfab
{
    public sealed class SaveProfilePlayfabButtonCommand : ButtonCommand
    {
        [SerializeField] private AccountSettingsScriptableObject _settings;
        [SerializeField] private ProfileSettingsData _profileSettingsData;
        [SerializeField] private TMPro.TMP_InputField _descriptionField;
        
        [SerializeField] private TMPro.TMP_Text _messageText;
        [SerializeField] private TMPro.TMP_Text _nameText;

        [SerializeField] private GameObject _window;

        [SerializeField] private ProfileInfoLoader _infoLoader;

        public override void Execute()
        {
            if (PlayerStaticStats.LoggedIn)
            {
                SaveRequest();
            }
        }

        void SaveRequest()
        {
            var request = new UpdateUserDataRequest
            {
                Data = new Dictionary<string, string>
                {
                    { "PictureId", _profileSettingsData._PPId.ToString() },
                    { "ColourId", _profileSettingsData._ColourId.ToString() },
                    { "Description", _descriptionField.text },
                    { "DisplayName", _nameText.text },
                },

                Permission = UserDataPermission.Public,
            };

            PlayFabClientAPI.UpdateUserData(request, OnSuccess, OnError);
        }

        private void OnError(PlayFabError error)
        {
            _messageText.text = error.ErrorMessage;
        }

        void OnSuccess(UpdateUserDataResult result)
        {
            _infoLoader.LoadInfo(_nameText.text, _descriptionField.text, _profileSettingsData._ColourId, _profileSettingsData._PPId);

            _window.SetActive(false);
        }
    }
}
