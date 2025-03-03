using System;
using System.Globalization;


namespace lab5 { 
class Program
{
    static void Main(string[] args)
    {
        // Исходный массив для тестирования
        int[] array = { 34, 12, 24, 9, 5, 3, 45, 30, 18, 7 };

        Console.WriteLine("Исходный массив:");
        PrintArray(array);

        // Тестирование сортировки расческой (CombSort)
        int[] combSortedArray = Sorter.CombSort((int[])array.Clone());
        Console.WriteLine("\nМассив после сортировки расческой:");
        PrintArray(combSortedArray);

        // Тестирование сортировки Шелла (ShellSort)
        int[] shellSortedArray = Sorter.ShellSort((int[])array.Clone(), array.Length);
        Console.WriteLine("\nМассив после сортировки Шелла:");
        PrintArray(shellSortedArray);

        // Тестирование поиска элемента (FindElement)
        int target = 24;
        int foundElement = Sorter.FindElement(array, target);
        if (foundElement != -1)
        {
            Console.WriteLine($"\nЭлемент {target} найден в массиве.");
        }
        else
        {
            Console.WriteLine($"\nЭлемент {target} не найден в массиве.");
        }

        // Тестирование вывода массива (PrintArray)
        Console.WriteLine("\nВывод массива с использованием PrintArray:");
        Console.WriteLine(Sorter.PrintArray(array));
    }

    // Вспомогательный метод для вывода массива
    static void PrintArray(int[] array)
    {
        foreach (int item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}
}