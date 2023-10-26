using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int currency;

    public void AddCurrency(int value)
    {
        currency += value;
    }

    public void RemoveCurrency(int value)
    {
        currency -= value;
    }
}
