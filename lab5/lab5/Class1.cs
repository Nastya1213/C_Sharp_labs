using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    public class Sorter
    {
        // Метод для обмена значений
        private static void Swap(ref int value1, ref int value2)
        {
            int temp = value1;
            value1 = value2;
            value2 = temp;
        }

        // Метод для вычисления следующего шага в сортировке расческой
        private static int GetNextStep(int step)
        {
            step = step * 1000 / 1247;
            return step > 1 ? step : 1;
        }

        // Метод для сортировки расческой
        public static int[] CombSort(int[] array)
        {
            int arrayLength = array.Length;
            int currentStep = arrayLength - 1;

            while (currentStep > 1)
            {
                for (int i = 0; i + currentStep < arrayLength; i++)
                {
                    if (array[i] > array[i + currentStep])
                    {
                        Swap(ref array[i], ref array[i + currentStep]);
                    }
                }

                currentStep = GetNextStep(currentStep);
            }

            // Дополнительная пузырьковая сортировка для окончательной доработки
            BubbleSort(array);

            return array;
        }

        // Метод для пузырьковой сортировки
        private static void BubbleSort(int[] array)
        {
            int arrayLength = array.Length;
            bool swapFlag;

            for (int i = 1; i < arrayLength; i++)
            {
                swapFlag = false;
                for (int j = 0; j < arrayLength - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        swapFlag = true;
                    }
                }

                if (!swapFlag)
                {
                    break;
                }
            }
        }

        // Метод для поиска элемента в массиве
        public static int FindElement(int[] array, int target)
        {
            foreach (int element in array)
            {
                if (element == target)
                {
                    return element;
                }
            }
            return -1; // Возвращаем -1, если элемент не найден
        }

        // Метод для сортировки Шелла
        public static int[] ShellSort(int[] array, int size)
        {
            for (int gap = size / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < size; i++)
                {
                    int temp = array[i];
                    int j;
                    for (j = i; j >= gap && array[j - gap] > temp; j -= gap)
                    {
                        array[j] = array[j - gap];
                    }
                    array[j] = temp;
                }
            }
            return array;
        }

        // Метод для вывода массива в строку
        public static string PrintArray(int[] array)
        {
            return string.Join(" ", array);
        }
    }
}
