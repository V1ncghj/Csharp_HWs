using System.Text.Json;

namespace Задача4;

internal class Program
{
    private static void Main()
    {
        // 1. Создаём персонажа с произвольными данными (минимум 3 предмета в инвентаре)
        var character = new GameCharacter
        {
            Name = "Артур",
            Level = 12,
            Health = 87.5,
            Inventory = new[] { "Меч", "Зелье здоровья", "Щит", "Карта сокровищ" }
        };

        // 2. Сериализуем в JSON-строку с отступами
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(character, options);

        // 3. Выводим JSON на экран
        Console.WriteLine("=== JSON персонажа ===");
        Console.WriteLine(json);

        // 4. Десериализуем строку обратно в новый объект
        GameCharacter restored = JsonSerializer.Deserialize<GameCharacter>(json);

        // 5. Проверяем, что данные восстановились корректно
        Console.WriteLine();
        Console.WriteLine("=== Восстановленный персонаж ===");
        Console.WriteLine($"Имя: {restored.Name}");
        Console.WriteLine($"Количество предметов в инвентаре: {restored.Inventory.Length}");
    }
}
