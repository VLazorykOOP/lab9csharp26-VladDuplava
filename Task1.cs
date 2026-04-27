using System;
using System.IO;
using System.Text.RegularExpressions;

namespace WordsStartingWithA
{
    class Program
    {
        static void Main(string[] args)
        {
            // Шлях до вхідного файлу
            string inputFile = "input.txt";

            // Перевірка наявності файлу
            if (!File.Exists(inputFile))
            {
                Console.WriteLine($"Помилка: Файл {inputFile} не знайдено!");
                Console.WriteLine("Створіть його в директорії з програмою.");
                return;
            }

            // 1. Читання тексту з файлу
            string text = File.ReadAllText(inputFile);
            Console.WriteLine("--- Оригінальний текст ---");
            Console.WriteLine(text);
            Console.WriteLine("--------------------------\n");

            // 2. Регулярний вираз для пошуку слів на літеру 'a' або 'а'
            // \b - позначає межу слова
            // [aа] - шукає англійську 'a' або українську 'а'
            // \p{L}* - шукає нуль або більше будь-яких літер (для продовження слова)
            string pattern = @"\b[aа]\p{L}*\b";

            // 3. Пошук збігів (RegexOptions.IgnoreCase робить пошук нечутливим до регістру: знайде і 'А', і 'а')
            MatchCollection matches = Regex.Matches(text, pattern, RegexOptions.IgnoreCase);

            // 4. Виведення результатів
            Console.WriteLine($"--- Знайдено слів на літеру 'А/а': {matches.Count} ---");
            
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    Console.WriteLine(match.Value);
                }
            }
            else
            {
                Console.WriteLine("Слів на літеру 'А/а' не знайдено.");
            }
            Console.WriteLine("-----------------------------------------");
        }
    }
}
