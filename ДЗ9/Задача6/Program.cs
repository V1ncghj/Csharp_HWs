using System.Text.Json;

namespace Задача6;

internal class Program
{
    private static void Main()
    {
        string settingsPath = Path.Combine(AppContext.BaseDirectory, "settings.json");

        if (File.Exists(settingsPath))
        {
            string json = File.ReadAllText(settingsPath);
            GameSettings settings = JsonSerializer.Deserialize<GameSettings>(json);

            Console.WriteLine("=== Текущие настройки ===");
            Console.WriteLine($"Имя игрока: {settings.PlayerName}");
            Console.WriteLine($"Сложность: {DifficultyToText(settings.Difficulty)} ({settings.Difficulty})");
            Console.WriteLine($"Громкость музыки: {settings.MusicVolume}");
        }
        else
        {
            Console.WriteLine("Файл настроек не найден. Создаём новые настройки.");

            var settings = new GameSettings();

            Console.Write("Введите имя игрока: ");
            settings.PlayerName = Console.ReadLine();

            Console.Write("Введите сложность (1 — легко, 2 — нормально, 3 — сложно): ");
            settings.Difficulty = int.Parse(Console.ReadLine());

            Console.Write("Введите громкость музыки (0–100): ");
            settings.MusicVolume = int.Parse(Console.ReadLine());

            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(settings, options);
            File.WriteAllText(settingsPath, json);

            Console.WriteLine($"\nНастройки сохранены в файл: {settingsPath}");
        }
    }

    private static string DifficultyToText(int difficulty) => difficulty switch
    {
        1 => "легко",
        2 => "нормально",
        3 => "сложно",
        _ => "неизвестно"
    };
}
