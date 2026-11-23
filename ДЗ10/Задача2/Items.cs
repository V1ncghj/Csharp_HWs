public enum Rarity
{
    Common,
    Rare,
    Epic
}

public class Player
{
    public int HP;
    public int Damage;
    public string Name;

    public Player(string name)
    {
        Name = name;
        HP = 100;
        Damage = 10;
    }

    public void Heal(int amount)
    {
        HP += amount;
    }

    public void IncreaseDamage(int amount)
    {
        Damage += amount;
    }
}

public interface IUsableItem
{
    string Name { get; }
    string Description { get; }
    Rarity Rarity { get; }
    void Use(Player player);
}

public class HealthPotion : IUsableItem
{
    public string Name => "Зелье здоровья";
    public string Description => "Восстанавливает 50 HP";
    public Rarity Rarity => global::Rarity.Common;

    public void Use(Player player)
    {
        player.Heal(50);
        Console.WriteLine("Вы выпили зелье и восстановили 50 HP.");
    }
}

public class Sword : IUsableItem
{
    public string Name => "Меч";
    public string Description => "Увеличивает урон на 10";
    public Rarity Rarity => global::Rarity.Rare;

    public void Use(Player player)
    {
        player.IncreaseDamage(10);
        Console.WriteLine("Вы взяли меч: урон увеличен на 10.");
    }
}

public class AncientScroll : IUsableItem
{
    public string Name => "Древний свиток";
    public string Description => "Проклятие: 20 урона, но урон увеличен на 30";
    public Rarity Rarity => global::Rarity.Epic;

    public void Use(Player player)
    {
        player.HP -= 20;
        player.IncreaseDamage(30);
        Console.WriteLine("Вы прочитали свиток: получено 20 урона, но урон увеличен на 30.");
    }
}
