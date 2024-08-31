using System.Diagnostics;

namespace ParallelFileSpaceCounter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь к папке с файлами:");
            string? folderPath = Console.ReadLine();

            if (string.IsNullOrEmpty(folderPath) || !Directory.Exists(folderPath))
            {
                Console.WriteLine("Указан некорректный путь.");
                return;
            }

            // Старт
            Stopwatch stopwatch = Stopwatch.StartNew();

            // Вычисление количества пробелов в файлах
            int totalSpaces = CountSpacesInFolder(folderPath).Result;

            // Остановка
            stopwatch.Stop();

            Console.WriteLine($"Общее количество пробелов: {totalSpaces}");
            Console.WriteLine($"Время выполнения: {stopwatch.ElapsedMilliseconds} мс");
        }

        static async Task<int> CountSpacesInFolder(string folderPath)
        {
            string[] files = Directory.GetFiles(folderPath);

            // Создание и запуск задач для параллельного чтения файлов и подсчета пробелов
            Task<int>[] tasks = files.Select(file => Task.Run(() => CountSpacesInFile(file))).ToArray();

            // Ожидание завершения всех задач и суммирование
            int[] results = await Task.WhenAll(tasks);
            return results.Sum();
        }

        static int CountSpacesInFile(string filePath)
        {
            // Чтение содержимого файла
            string content = File.ReadAllText(filePath);

            return content.Count(c => c == ' ');
        }
    }
}
