using Client.Runtime.Framework.Unity;
using PlayFab.ClientModels;
using PlayFab;
using UnityEngine;
using UnityEngine.UI;

namespace Client.Runtime.Activities.Lobby.Commands.ButtonCommands.Playfab
{
    public sealed class RestorePasswordPlayfabButtonCommand : ButtonCommand
    {
        [SerializeField] private TMPro.TMP_InputField _emailField;
        
        [SerializeField] private TMPro.TMP_Text _messageText;

        public override void Execute()
        {
            RestoreRequest();
        }

        void RestoreRequest()
        {
            var request = new SendAccountRecoveryEmailRequest
            {
                Email = _emailField.text,
                TitleId = "135D3",
            };

            PlayFabClientAPI.SendAccountRecoveryEmail(request, OnSuccess, OnError);
        }

        private void OnError(PlayFabError error)
        {
            _messageText.text = error.ErrorMessage;
        }

        void OnSuccess(SendAccountRecoveryEmailResult result)
        {
            _messageText.text = "Password reset mail sent!";
        }
    }
}
