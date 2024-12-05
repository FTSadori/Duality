using UnityEngine;
using TMPro;

namespace Client.Runtime.Activities.Lobby.Base
{
    public sealed class PriceLabelController : MonoBehaviour
    {
        [SerializeField] TMP_Text _priceLabel;
        [SerializeField] string _itemId;
        private int _price;

        public string ItemId => _itemId;
        public int Price => _price;

        public void UpdatePrice(int price)
        {
            _price = price;
            _priceLabel.text = price.ToString() + " SH";
        }
    }
}
