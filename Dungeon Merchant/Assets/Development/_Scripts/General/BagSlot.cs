using System;
using UnityEngine;
using UnityEngine.UI;

public class BagSlot : MonoBehaviour
{
    Item item;
    [SerializeField] Image itemIcon;

    public void SetItem(Item itemInfo)
    {
        item = itemInfo;
        itemIcon.gameObject.SetActive(true);
        itemIcon.sprite = item.itemIcon;
    }

    public void RemoveItem()
    {
        item = null;
        itemIcon.gameObject.SetActive(false);
        itemIcon.sprite = null;
    }

    public void EquipOrSell()
    {
        if (item == null) return;

        if (Inventory.Instance.shopActive)
        {
            GameManager.Instance.AddCurrency(item.sellPrice);
            Inventory.Instance.RemoveItem(item);
            RemoveItem();
        }
        else
        {
            if (Inventory.Instance.EquipItem(item))
                RemoveItem();
        }
    }
}
