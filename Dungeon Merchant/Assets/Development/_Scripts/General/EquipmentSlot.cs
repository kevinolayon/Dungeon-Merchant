using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour
{
    Item item;

    [SerializeField] ItemType itemType;
    [SerializeField] Image itemIcon;

    public void SetItem(Item itemInfo)
    {
        item = itemInfo;
        itemIcon.gameObject.SetActive(true);
        itemIcon.sprite = item.itemIcon;
    }

    public void UnequipItem()
    {
        Inventory.Instance.AddItem(item);

        switch (item.itemType)
        {
            case ItemType.Helmet:
                Player.Instance.HideHelmet();
                break;
            case ItemType.Armor:
                Player.Instance.HideArmor();
                break;
        }

        item = null;
        itemIcon.gameObject.SetActive(false);
        itemIcon.sprite = null;
    }

    public bool CheckType(ItemType type)
    {
        if (itemType == type)
        {
            if (item == null)
            {
                return true;
            }
        }

        return false;
    }
}
