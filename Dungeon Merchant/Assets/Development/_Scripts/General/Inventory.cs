using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{
    [SerializeField] TextMeshProUGUI currentCurrency;

    [SerializeField] List<EquipmentSlot> equipSlot = new();
    [SerializeField] List<Item> inventoryList = new();
    [SerializeField] List<BagSlot> bagSlots = new();

    public bool shopActive;
    
    void Start()
    {
        currentCurrency.text = GameManager.Instance.currency.ToString("N");
    }

    public void UpdateCurrency()
    {
        currentCurrency.text = GameManager.Instance.currency.ToString("N");
    }

    public bool EquipItem(Item item)
    {
        for (int i = 0; i < equipSlot.Count; i++)
        {
            if (equipSlot[i].CheckType(item.itemType))
            {
                switch (item.itemType)
                {
                    case ItemType.Helmet:
                        Player.Instance.ShowHelmet();
                        break;
                    case ItemType.Armor:
                        Player.Instance.ShowArmor();
                        break;
                }

                equipSlot[i].SetItem(item);
                RemoveItem(item);

                return true;
            }
        }

        return false;
    }

    public void AddItem(Item item)
    {
        inventoryList.Add(item);

        for (int i = 0; i < inventoryList.Count; i++)
        {
            bagSlots[i].SetItem(inventoryList[i]);
        }
    }

    public void RemoveItem(Item item)
    {
        inventoryList.Remove(item);
        UpdateCurrency();
    }
}
