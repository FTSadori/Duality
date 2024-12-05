using Assets.Project.Activities.Sources.Client.Runtime.Activities.Lobby.Base;
using Client.Runtime.Activities.Lobby.Base;
using Client.Runtime.Framework.Unity;
using UnityEngine;
using UnityEngine.UI;

namespace Client.Runtime.Activities.Lobby.Commands.ButtonCommands
{
    public sealed class PickProfilePictureButtonCommand : PickItemButtonCommand
    {
        [SerializeField] private ProfileSettingsData _profileSettingsData;
        [SerializeField] private ProfilePictureLoader _profilePictureLoader;
        [SerializeField] private Image _profilePicture;
        [SerializeField] private GameObject _priceLabel;
        [SerializeField] private bool _isBlocked = true;

        public override PriceLabelController PriceLabelController => _priceLabel.GetComponent<PriceLabelController>();

        public void Start()
        {
            if (!_isBlocked)
            {
                _priceLabel.SetActive(false);
            }
        }

        public override void Execute()
        {
            if (!_isBlocked)
            {
                _profileSettingsData._PPId = _profilePictureLoader.Id;
                _profilePicture.sprite = _profilePictureLoader.Sprite;
            }
        }

        public override void Unblock()
        {
            _isBlocked = false;
            _priceLabel.SetActive(false);
        }
    }
}
