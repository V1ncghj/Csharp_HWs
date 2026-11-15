using System.Text.Json;

namespace Задача5;

internal class Program
{
    private static void Main()
    {
        // 1. Создаём персонажа с произвольными данными (минимум 3 предмета в инвентаре)
        var character = new GameCharacter
        {
            Name = "Мира",
            Level = 7,
            Health = 63.25,
            Inventory = new[] { "Лук", "Стрелы", "Кинжал", "Факел", "Верёвка" }
        };

        // 2. Сериализуем в JSON-строку с отступами
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(character, options);

        Console.WriteLine("=== JSON персонажа ===");
        Console.WriteLine(json);

        // 3. Сохраняем JSON-строку в файл save.json с помощью класса File
        string savePath = Path.Combine(AppContext.BaseDirectory, "save.json");
        File.WriteAllText(savePath, json);
        Console.WriteLine($"\nСохранение записано в файл: {savePath}");

        // 4. Читаем содержимое файла обратно и десериализуем в новый объект
        string loadedJson = File.ReadAllText(savePath);
        GameCharacter restored = JsonSerializer.Deserialize<GameCharacter>(loadedJson);

        // 5. Выводим все данные восстановленного персонажа в удобочитаемом формате
        Console.WriteLine();
        Console.WriteLine("=== Загруженный персонаж ===");
        Console.WriteLine($"Имя: {restored.Name}");
        Console.WriteLine($"Уровень: {restored.Level}");
        Console.WriteLine($"Здоровье: {restored.Health}");
        Console.WriteLine($"Инвентарь: {string.Join(", ", restored.Inventory)}");
    }
}
