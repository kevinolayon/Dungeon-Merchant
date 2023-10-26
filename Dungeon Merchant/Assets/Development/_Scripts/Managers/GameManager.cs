public enum ItemType { Helmet, Armor }

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
