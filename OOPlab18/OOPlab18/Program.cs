// See https://aka.ms/new-console-template for more information
using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        double[] array = { -2, 0, 3, -4, 5, 0, -7 }; // Приклад масиву (можна змінити)

        Console.WriteLine("Початковий масив:");
        PrintArray(array);

        double maxAbsElement = CalculateMaxAbsoluteElement(array);
        Console.WriteLine($"Максимальний за модулем елемент масиву: {maxAbsElement}");

        double sumBetweenPositive = CalculateSumBetweenPositiveElements(array);
        Console.WriteLine($"Сума елементів масиву, розташованих між першим і другим додатними: {sumBetweenPositive}");

        TransformArray(array);

        Console.WriteLine("Масив після перетворення:");
        PrintArray(array);
    }

    static double CalculateMaxAbsoluteElement(double[] array)
    {
        double maxAbsElement = Math.Abs(array[0]);
        for (int i = 1; i < array.Length; i++)
        {
            double absElement = Math.Abs(array[i]);
            if (absElement > maxAbsElement)
            {
                maxAbsElement = absElement;
            }
        }
        return maxAbsElement;
    }

    static double CalculateSumBetweenPositiveElements(double[] array)
    {
        int firstPositiveIndex = -1;
        int secondPositiveIndex = -1;

        // Знаходимо індекси першого та другого додатних елементів
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] > 0)
            {
                if (firstPositiveIndex == -1)
                {
                    firstPositiveIndex = i;
                }
                else
                {
                    secondPositiveIndex = i;
                    break;
                }
            }
        }

        // Перевірка чи знайдено обидва додатні елементи
        if (firstPositiveIndex == -1 || secondPositiveIndex == -1)
        {
            Console.WriteLine("Не знайдено два додатніх елементи для обчислення суми між ними.");
            return 0;
        }

        // Обчислення суми елементів масиву між першим і другим додатними
        double sum = 0;
        for (int i = firstPositiveIndex + 1; i < secondPositiveIndex; i++)
        {
            sum += array[i];
        }
        return sum;
    }

    static void TransformArray(double[] array)
    {
        // Створюємо новий масив, в якому нулі розміщуються в кінці
        double[] transformedArray = array.Where(x => x != 0).Concat(array.Where(x => x == 0)).ToArray();

        // Копіюємо елементи з transformedArray назад в оригінальний масив
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = transformedArray[i];
        }
    }

    static void PrintArray(double[] array)
    {
        foreach (var element in array)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }
}
