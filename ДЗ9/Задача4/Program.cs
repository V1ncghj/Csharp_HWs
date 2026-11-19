using System.Text.Json;

namespace Задача4;

internal class Program
{
    private static void Main()
    {
        var character = new GameCharacter
        {
            Name = "Артур",
            Level = 12,
            Health = 87.5,
            Inventory = new[] { "Меч", "Зелье здоровья", "Щит", "Карта сокровищ" }
        };

        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(character, options);

        Console.WriteLine("=== JSON персонажа ===");
        Console.WriteLine(json);

        GameCharacter restored = JsonSerializer.Deserialize<GameCharacter>(json);

        Console.WriteLine();
        Console.WriteLine("=== Восстановленный персонаж ===");
        Console.WriteLine($"Имя: {restored.Name}");
        Console.WriteLine($"Количество предметов в инвентаре: {restored.Inventory.Length}");
    }
}
