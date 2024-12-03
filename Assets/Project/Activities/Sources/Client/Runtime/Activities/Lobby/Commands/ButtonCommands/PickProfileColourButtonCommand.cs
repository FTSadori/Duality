using Assets.Project.Activities.Sources.Client.Runtime.Activities.Lobby.Base;
using Client.Runtime.Activities.Lobby.Base;
using Client.Runtime.Framework.Unity;
using UnityEngine;
using UnityEngine.UI;

namespace Client.Runtime.Activities.Lobby.Commands.ButtonCommands
{
    public sealed class PickProfileColourButtonCommand : ButtonCommand
    {
        [SerializeField] private ProfileSettingsData _profileSettingsData;
        [SerializeField] private ProfileColourLoader _profileColourLoader;
        [SerializeField] private Image _profilePicture;

        public override void Execute()
        {
            _profilePicture.color = _profileColourLoader.Color;
            _profileSettingsData._ColourId = _profileColourLoader.Id;
        }
    }
}
