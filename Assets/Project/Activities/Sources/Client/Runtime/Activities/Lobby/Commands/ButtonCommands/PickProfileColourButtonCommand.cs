using Assets.Project.Activities.Sources.Client.Runtime.Activities.Lobby.Base;
using Client.Runtime.Activities.Lobby.Base;
using Client.Runtime.Framework.Unity;
using UnityEngine;
using UnityEngine.UI;

namespace Client.Runtime.Activities.Lobby.Commands.ButtonCommands
{
    public sealed class PickProfileColourButtonCommand : PickItemButtonCommand
    {
        [SerializeField] private ProfileSettingsData _profileSettingsData;
        [SerializeField] private ProfileColourLoader _profileColourLoader;
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
                _profilePicture.color = _profileColourLoader.Color;
                _profileSettingsData._ColourId = _profileColourLoader.Id;
            }
        }

        public override void Unblock()
        {
            _isBlocked = false;
            _priceLabel.SetActive(false);
        }
    }
}
