using Assets.Project.Activities.Sources.Client.Runtime.Activities.Lobby.Base;
using Client.Runtime.Activities.Lobby.Base;
using Client.Runtime.Framework.Unity;
using UnityEngine;
using UnityEngine.UI;

namespace Client.Runtime.Activities.Lobby.Commands.ButtonCommands
{
    public sealed class PickProfilePictureButtonCommand : ButtonCommand
    {
        [SerializeField] private ProfileSettingsData _profileSettingsData;
        [SerializeField] private ProfilePictureLoader _profilePictureLoader;
        [SerializeField] private Image _profilePicture;

        public override void Execute()
        {
            _profileSettingsData._PPId = _profilePictureLoader.Id;
            _profilePicture.sprite = _profilePictureLoader.Sprite;
        }
    }
}
