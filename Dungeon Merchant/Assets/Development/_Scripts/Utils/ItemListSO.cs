using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables", fileName = "ItemList")]
public class ItemListSO : ScriptableObject
{
    public List<Item> itemList;
}

[System.Serializable]
public class Item
{
    public string itemName;
    public Sprite itemIcon;
    public ItemType itemType;
    public int buyPrice;
    public int sellPrice;
}