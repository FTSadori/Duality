using Client.Runtime.Framework.Unity;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using UnityEngine;
using Client.Runtime.Activities.Lobby.Base;
using Client.Runtime.Activities.Game.Base;

namespace Client.Runtime.Activities.Lobby.Commands.ButtonCommands.Playfab
{
    public sealed class RegistrationPlayfabButtonCommand : ButtonCommand
    {
        [SerializeField] private TMPro.TMP_InputField _usernameField;
        [SerializeField] private TMPro.TMP_InputField _emailField;
        [SerializeField] private TMPro.TMP_InputField _passwordField;

        [SerializeField] private TMPro.TMP_Text _messageText;

        [SerializeField] private GameObject _registerWindow;
        [SerializeField] private GameObject _addAccountButton;
        [SerializeField] private GameObject _profileButton;

        [SerializeField] private SaveProfilePlayfabButtonCommand _saveProfileInfo;
        [SerializeField] private ProfileInfoLoader _infoLoader;

        public override void Execute()
        {
            RegisterRequest();
        }

        void RegisterRequest()
        {
            var request = new RegisterPlayFabUserRequest
            {
                Email = _emailField.text,
                Password = _passwordField.text,
                DisplayName = _usernameField.text,
                RequireBothUsernameAndEmail = false,
            };

            PlayFabClientAPI.RegisterPlayFabUser(request, OnSuccess, OnError);
        }

        private void OnError(PlayFabError error)
        {
            _messageText.text = error.ErrorMessage;
        }

        void OnSuccess(RegisterPlayFabUserResult result)
        {
            _addAccountButton.SetActive(false);
            _profileButton.SetActive(true);
            _registerWindow.SetActive(false);

            PlayerStaticStats.LoggedIn = true;

            PlayerStaticStats.PlayerID = result.PlayFabId;
            _infoLoader.LoadInfo(_usernameField.text, "Fill it", 0, 0);
            _saveProfileInfo.Execute();
        }
    }
}
