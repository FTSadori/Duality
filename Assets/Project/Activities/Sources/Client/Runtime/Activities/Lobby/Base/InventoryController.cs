using UnityEngine;
using TMPro;
using PlayFab;
using PlayFab.ClientModels;
using System;
using System.Collections.Generic;
using Client.Runtime.Activities.Lobby.Commands.ButtonCommands;

namespace Client.Runtime.Activities.Lobby.Base
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField] TMP_Text _currencyText;
        [SerializeField] TMP_Text _errorMessage;

        [SerializeField] List<string> _itemsIds;
        [SerializeField] List<PickItemButtonCommand> _itemsCommands;

        private void OnEnable()
        {
            LoadCatalogue();
        }

        private void LoadCatalogue()
        {
            var request = new GetCatalogItemsRequest
            {
                CatalogVersion = "ProfileCatalog"
            };

            PlayFabClientAPI.GetCatalogItems(request, OnGetCatalogSuccess, OnError);
        }

        private void OnGetCatalogSuccess(GetCatalogItemsResult result)
        {
            foreach (var item in result.Catalog)
            {
                int index = _itemsIds.FindIndex(it => it == item.ItemId);
                if (index != -1)
                {
                    _itemsCommands[index].PriceLabelController.UpdatePrice((int)item.VirtualCurrencyPrices["SH"]);
                }
            }

            UpdateInventory();
        }

        public void UpdateInventory()
        {
            PlayFabClientAPI.GetUserInventory(new GetUserInventoryRequest(), OnGetUserInventory, OnError);
        }

        void OnGetUserInventory(GetUserInventoryResult result)
        {
            int shards = result.VirtualCurrency["SH"];
            _currencyText.text = shards.ToString() + " shards";

            foreach (var item in result.Inventory)
            {
                int index = _itemsIds.FindIndex(it => it == item.ItemId);
                if (index != -1)
                {
                    _itemsCommands[index].Unblock();
                }
            }
        }

        void OnError(PlayFabError error)
        {
            _errorMessage.text = error.ErrorMessage;
        }
    }
}
