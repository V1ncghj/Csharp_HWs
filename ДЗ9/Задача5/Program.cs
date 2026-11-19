using System.Text.Json;

namespace Задача5;

internal class Program
{
    private static void Main()
    {
        var character = new GameCharacter
        {
            Name = "Мира",
            Level = 7,
            Health = 63.25,
            Inventory = new[] { "Лук", "Стрелы", "Кинжал", "Факел", "Верёвка" }
        };

        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(character, options);

        Console.WriteLine("=== JSON персонажа ===");
        Console.WriteLine(json);

        string savePath = Path.Combine(AppContext.BaseDirectory, "save.json");
        File.WriteAllText(savePath, json);
        Console.WriteLine($"\nСохранение записано в файл: {savePath}");

        string loadedJson = File.ReadAllText(savePath);
        GameCharacter restored = JsonSerializer.Deserialize<GameCharacter>(loadedJson);

        Console.WriteLine();
        Console.WriteLine("=== Загруженный персонаж ===");
        Console.WriteLine($"Имя: {restored.Name}");
        Console.WriteLine($"Уровень: {restored.Level}");
        Console.WriteLine($"Здоровье: {restored.Health}");
        Console.WriteLine($"Инвентарь: {string.Join(", ", restored.Inventory)}");
    }
}
