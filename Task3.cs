using System;
using System.IO;

namespace MaxNegativeMinPositive
{
    class Program
    {
        static void Main(string[] args)
        {
            // Шлях до файлу
            string filePath = "sequence_results.txt";

            // Дана послідовність дійсних чисел
            double[] sequence = { -5.5, 3.2, -1.1, 8.4, 0.0, -9.9, 2.1 };

            Console.WriteLine("--- Початкова послідовність ---");
            Console.WriteLine(string.Join(", ", sequence));
            Console.WriteLine("-------------------------------\n");

            // 1. Записуємо початкову послідовність у файл
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Початкова послідовність дійсних чисел:");
                foreach (double number in sequence)
                {
                    writer.WriteLine(number);
                }
            }
            Console.WriteLine($"Послідовність успішно записано у файл: {filePath}\n");

            // 2. Шукаємо найбільше серед від'ємних і найменше серед додатних
            // Використовуємо nullable типи (double?), щоб обробити ситуацію, 
            // коли в масиві взагалі немає додатних або від'ємних чисел
            double? maxNegative = null;
            double? minPositive = null;

            foreach (double number in sequence)
            {
                if (number < 0) // Якщо число від'ємне
                {
                    // Якщо ми ще не знайшли жодного від'ємного АБО поточне більше за знайдене раніше
                    if (maxNegative == null || number > maxNegative)
                    {
                        maxNegative = number;
                    }
                }
                else if (number > 0) // Якщо число додатне
                {
                    // Якщо ми ще не знайшли жодного додатного АБО поточне менше за знайдене раніше
                    if (minPositive == null || number < minPositive)
                    {
                        minPositive = number;
                    }
                }
                // Нуль (0) ігноруємо, бо він ані додатний, ані від'ємний
            }

            // 3. Формуємо результати
            string resultMessage = "\n--- Результати обчислень ---\n";
            
            if (maxNegative != null)
                resultMessage += $"Найбільше серед від'ємних: {maxNegative}\n";
            else
                resultMessage += "У послідовності немає від'ємних чисел.\n";

            if (minPositive != null)
                resultMessage += $"Найменше серед додатних: {minPositive}\n";
            else
                resultMessage += "У послідовності немає додатних чисел.\n";

            // 4. Долучаємо результати у кінець файлу
            File.AppendAllText(filePath, resultMessage);

            // Виводимо результати на екран
            Console.WriteLine(resultMessage.Trim());
            Console.WriteLine("\nРезультати успішно долучено до файлу!");
        }
    }
}
