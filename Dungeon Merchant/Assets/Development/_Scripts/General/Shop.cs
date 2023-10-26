using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shop : MonoBehaviour
{
    public TextMeshProUGUI itemPrice;
    Item itemSelected;

    public List<Item> itemList = new();
    public List<ShopSlot> shopSlots = new();

    private void Start()
    {
        itemPrice.text = "0";

        foreach (var slot in shopSlots)
        {
            slot.itemSelected += ItemSelected;
            slot.itemDeselected += ItemDeselected;
        }

        for (int i = 0; i < itemList.Count; i++)
        {
            shopSlots[i].SetItem(itemList[i]);
        }
    }

    public void ItemSelected(Item item)
    {
        itemPrice.text = item.buyPrice.ToString("N");
        itemSelected = item;
    }

    public void ItemDeselected(BaseEventData eventData)
    {
        if (eventData.selectedObject == null)
        {
            itemPrice.text = "0";
            itemSelected = null;
        }
    }

    public void BuyItem()
    {
        if (itemSelected == null) return;

        if (GameManager.Instance.currency >= itemSelected.buyPrice)
        {
            GameManager.Instance.RemoveCurrency(itemSelected.buyPrice);
            Inventory.Instance.UpdateCurrency();
            Inventory.Instance.AddItem(itemSelected);
        }
    }
}
