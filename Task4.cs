using System;
using System.IO;
using System.Linq;

namespace DivideByMaxElement
{
    class Program
    {
        static void Main(string[] args)
        {
            // Шлях до файлу для збереження результату
            string filePath = "divided_array.txt";

            // Дано масив цілих чисел
            int[] numbers = { 15, -10, 25, 5, 0, 42, 8, -3 };

            Console.WriteLine("--- Початковий масив ---");
            Console.WriteLine(string.Join(", ", numbers));
            Console.WriteLine("------------------------\n");

            // 1. Знаходимо найбільший елемент масиву
            // Можна використати цикл, але метод Max() з бібліотеки System.Linq робить це в один рядок
            int maxElement = numbers.Max();
            Console.WriteLine($"Найбільший елемент масиву: {maxElement}\n");

            // Перевірка, щоб уникнути ділення на нуль
            if (maxElement == 0)
            {
                Console.WriteLine("Помилка: Найбільший елемент дорівнює нулю. Ділення на нуль неможливе!");
                return;
            }

            // 2. Створюємо новий масив для збереження результатів (тип double для дробів)
            double[] resultArray = new double[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                // Приводимо до (double), щоб отримати точний дробовий результат
                resultArray[i] = (double)numbers[i] / maxElement; 
            }

            // 3. Записуємо отриманий масив у файл
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"Максимальний елемент, на який ділили: {maxElement}");
                writer.WriteLine("Отриманий масив:");
                
                foreach (double result in resultArray)
                {
                    // Math.Round(result, 4) округлює число до 4 знаків після коми для красивого виводу
                    writer.WriteLine(Math.Round(result, 4));
                }
            }

            Console.WriteLine("--- Отриманий масив (після ділення) ---");
            Console.WriteLine(string.Join(", ", resultArray.Select(x => Math.Round(x, 4))));
            Console.WriteLine("---------------------------------------\n");
            
            Console.WriteLine($"Результат успішно записано у файл: {filePath}");
        }
    }
}
