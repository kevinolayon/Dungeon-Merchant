using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{
    [SerializeField] TextMeshProUGUI currentCurrency;
    [SerializeField] List<Item> itemList = new();

    void Start()
    {
        currentCurrency.text = GameManager.Instance.currency.ToString("N");
    }

    public void UpdateCurrency()
    {
        currentCurrency.text = GameManager.Instance.currency.ToString("N");
    }

    public void AddItem()
    {

    }
}
