using Client.Runtime.Activities.Game.Base;
using Client.Runtime.Activities.Lobby.Base;
using Client.Runtime.Framework.Unity;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

namespace Client.Runtime.Activities.Lobby.Commands.ButtonCommands.Playfab
{
    public sealed class LoginPlayfabButtonCommand : ButtonCommand
    {
        [SerializeField] private TMPro.TMP_InputField _emailField;
        [SerializeField] private TMPro.TMP_InputField _passwordField;

        [SerializeField] private TMPro.TMP_Text _messageText;

        [SerializeField] private GameObject _loginWindow;
        [SerializeField] private GameObject _addAccountButton;
        [SerializeField] private GameObject _profileButton;

        [SerializeField] private ProfilePlayfabGetter _infoGetter;

        public override void Execute()
        {
            LoginRequest();
        }

        void LoginRequest()
        {
            var request = new LoginWithEmailAddressRequest
            {
                Email = _emailField.text,
                Password = _passwordField.text,
            };

            PlayFabClientAPI.LoginWithEmailAddress(request, OnSuccess, OnError);
        }

        private void OnError(PlayFabError error)
        {
            _messageText.text = error.ErrorMessage;
        }

        void OnSuccess(LoginResult result)
        {
            _addAccountButton.SetActive(false);
            _profileButton.SetActive(true);
            _loginWindow.SetActive(false);

            PlayerStaticStats.LoggedIn = true;

            PlayerStaticStats.PlayerID = result.PlayFabId;
            _infoGetter.Execute();
        }
    }
}
