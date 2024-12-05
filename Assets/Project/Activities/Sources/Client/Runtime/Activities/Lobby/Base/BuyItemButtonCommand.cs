using Client.Runtime.Framework.Unity;
using UnityEngine;
using TMPro;
using PlayFab.ClientModels;
using PlayFab;
using System;

namespace Client.Runtime.Activities.Lobby.Base
{
    public sealed class BuyItemButtonCommand : ButtonCommand
    {
        [SerializeField] PriceLabelController _label;
        [SerializeField] TMP_Text _errorMessage;
        [SerializeField] InventoryController _inventoryController;

        public override void Execute()
        {
            var request = new PurchaseItemRequest
            {
                ItemId = _label.ItemId,
                VirtualCurrency = "SH",
                Price = _label.Price,
            };

            PlayFabClientAPI.PurchaseItem(request, OnSuccess, OnError);
        }

        private void OnSuccess(PurchaseItemResult result)
        {
            _inventoryController.UpdateInventory();
        }

        void OnError(PlayFabError error)
        {
            _errorMessage.text = error.ErrorMessage;
        }
    }
}
