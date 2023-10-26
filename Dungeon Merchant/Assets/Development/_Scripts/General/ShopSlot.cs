using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour, IDeselectHandler
{
    Item item; // Reference of the item on the slot

    [SerializeField] Image itemIcon;
    [SerializeField] Image selected;

    public Action<Item> itemSelected;
    public Action<BaseEventData> itemDeselected;

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

    public void Selected()
    {
        selected.gameObject.SetActive(true);
        if (item != null)
            itemSelected?.Invoke(item);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        selected.gameObject.SetActive(false);
        itemDeselected?.Invoke(eventData);
    }
}
