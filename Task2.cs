using System;
using System.IO;

namespace FirstAndLastPositiveSum
{
    class Program
    {
        static void Main(string[] args)
        {
            // Шлях до файлу (буде створений у папці з програмою)
            string filePath = "sequence.txt";

            // Дана послідовність дійсних чисел (double)
            double[] sequence = { -3.5, 2.1, 0.0, -1.2, 4.5, 6.7, -8.9, 1.1, -2.0 };

            Console.WriteLine("--- Початкова послідовність ---");
            Console.WriteLine(string.Join(", ", sequence));
            Console.WriteLine("-------------------------------\n");

            // 1. Створюємо файл та записуємо в нього послідовність
            // Використовуємо StreamWriter для побудкового запису
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Послідовність дійсних чисел:");
                foreach (double number in sequence)
                {
                    writer.WriteLine(number);
                }
            }
            Console.WriteLine($"Послідовність успішно записано у файл: {filePath}");

            // 2. Знаходимо перший та останній додатні елементи
            // Використовуємо nullable тип double? (може бути null), щоб знати, чи знайшли ми взагалі додатні числа
            double? firstPositive = null;
            double? lastPositive = null;

            foreach (double number in sequence)
            {
                if (number > 0)
                {
                    // Якщо перший додатний ще не знайдено, записуємо його
                    if (firstPositive == null)
                    {
                        firstPositive = number;
                    }
                    
                    // Останній додатний постійно перезаписується, 
                    // тому в кінці циклу тут залишиться справді останній знайдений
                    lastPositive = number; 
                }
            }

            // 3. Обчислюємо суму та долучаємо у файл
            // File.AppendAllText відкриває файл, дописує текст у кінець і закриває його
            if (firstPositive != null && lastPositive != null)
            {
                double sum = firstPositive.Value + lastPositive.Value;
                
                string resultMessage = $"\nПерший додатний: {firstPositive}\n" +
                                       $"Останній додатний: {lastPositive}\n" +
                                       $"Їхня сума: {sum}";
                
                File.AppendAllText(filePath, resultMessage);
                
                Console.WriteLine(resultMessage);
                Console.WriteLine("\nСуму успішно долучено до файлу!");
            }
            else
            {
                string errorMessage = "\nУ послідовності немає додатних елементів.";
                File.AppendAllText(filePath, errorMessage);
                Console.WriteLine(errorMessage);
            }
        }
    }
}
