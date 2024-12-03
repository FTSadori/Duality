using Client.Runtime.Activities.Lobby.Base;
using Client.Runtime.Framework.Unity;
using PlayFab;
using UnityEngine;
using PlayFab.ClientModels;
using Client.Runtime.Activities.Game.Base;

namespace Client.Runtime.Activities.Lobby.Commands.ButtonCommands.Playfab
{
    public sealed class ProfilePlayfabGetter : MonoCommand
    {
        [SerializeField] ProfileInfoLoader _loader;

        [SerializeField] GameObject _linkButton;
        [SerializeField] GameObject _profile;

        private void Start()
        {
            Execute();
        }

        public override void Execute()
        {
            if (PlayerStaticStats.LoggedIn)
            {
                _linkButton.SetActive(false);
                _profile.SetActive(true);

                PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnSuccess, OnError);
            }
        }

        private void OnError(PlayFabError error)
        {
            Debug.Log("Can't get user data in ProfilePlayfabGetter");
        }

        void OnSuccess(GetUserDataResult result)
        {
            if (result.Data == null)
            {
                Debug.Log("User data is empty");
                return;
            }
            Debug.Log("User data is present");

            if (result.Data.ContainsKey("PictureId") && 
                result.Data.ContainsKey("ColourId") && 
                result.Data.ContainsKey("Description") &&
                result.Data.ContainsKey("DisplayName"))
            {
                _loader.LoadInfo(result.Data["DisplayName"].Value, result.Data["Description"].Value,
                    int.Parse(result.Data["ColourId"].Value), int.Parse(result.Data["PictureId"].Value));
            }
        }
    }
}
