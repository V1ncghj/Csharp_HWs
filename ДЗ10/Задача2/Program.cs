Player player = new Player("Герой");

List<IUsableItem> items = new List<IUsableItem>
{
    new HealthPotion(),
    new Sword(),
    new AncientScroll()
};

foreach (IUsableItem item in items)
{
    item.Use(player);
}

Console.WriteLine($"Итог: {player.Name}, HP: {player.HP}, урон: {player.Damage}");
Console.WriteLine(player.HP > 0 ? "Игрок жив." : "Игрок мёртв.");
