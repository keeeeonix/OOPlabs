using System;

class Program
{
    static void Main(string[] args)
    {
        int[,] array = {
            { 1, 2, 3, 4, 5 },
            { 6, 7, 8, 9, 10 },
            { 11, 12, 13, 14, 15 },
            { 16, 17, 18, 19, 20 },
            { 21, 22, 23, 24, 25 }
        }; // Приклад двовимірного масиву 5x5

        Console.WriteLine("Двовимірний масив:");
        PrintArray(array);

        int sumOfTwoElements = CalculateSumOfTwoElementsInSecondRow(array, 0, 2); // Приклад розрахунку суми двох будь-яких елементів другого рядка
        Console.WriteLine($"Сума двох елементів другого рядка: {sumOfTwoElements}");

        int productOfTwoElements = CalculateProductOfTwoElementsInFifthColumn(array, 1, 2); // Приклад розрахунку добутку двох будь-яких елементів п’ятого стовбця
        Console.WriteLine($"Добуток двох елементів п'ятого стовбця: {productOfTwoElements}");
    }

    static int CalculateSumOfTwoElementsInSecondRow(int[,] array, int columnIndex1, int columnIndex2)
    {
        int sum = array[1, columnIndex1] + array[1, columnIndex2];
        return sum;
    }

    static int CalculateProductOfTwoElementsInFifthColumn(int[,] array, int rowIndex1, int rowIndex2)
    {
        int columnIndex = array.GetLength(1) - 1; // Отримуємо індекс останнього стовпця
        int product = array[rowIndex1, columnIndex] * array[rowIndex2, columnIndex];
        return product;
    }

    static void PrintArray(int[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                Console.Write(array[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}
