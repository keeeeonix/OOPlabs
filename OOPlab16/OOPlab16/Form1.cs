using System;
using System.Numerics; // Для комплексних чисел
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace OOPlab16
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Отримуємо рядок введених комплексних чисел з текстового поля
            string input = textBoxInput.Text;

            // Розділяємо введений рядок на окремі комплексні числа за допомогою пробілів
            string[] complexNumbersStrings = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            // Створюємо масив комплексних чисел для обробки
            Complex[] complexNumbers = new Complex[complexNumbersStrings.Length];

            // Парсимо кожний рядок і перетворюємо його в комплексне число
            for (int i = 0; i < complexNumbersStrings.Length; i++)
            {

                string[] parts = complexNumbersStrings[i].Split('+', '-');
                double realPart;
                if (!string.IsNullOrEmpty(parts[0]))
                {
                    realPart = double.Parse(parts[0]);
                }
                else
                {
                    realPart = 0; // Припускаємо, що реальна частина дорівнює 0, якщо вона не вказана
                }
                double imaginaryPart;
                if (parts.Length > 2)
                {
                    imaginaryPart = double.Parse(parts[1] + parts[2].Trim('i'));
                }
                else
                {
                    imaginaryPart = double.Parse(parts[1].Trim('i'));
                }
                complexNumbers[i] = new Complex(realPart, imaginaryPart);
            }

            // Створюємо масив для зберігання модулів сум комплексних чисел, що стоять поруч
            double[] moduli = new double[complexNumbers.Length - 1];

            // Обчислюємо модулі сум комплексних чисел, що стоять поруч
            for (int i = 0; i < moduli.Length; i++)
            {
                moduli[i] = Complex.Abs(complexNumbers[i] + complexNumbers[i + 1]);
            }

            // Формуємо рядок для виведення результатів
            string result = "Модулі сум комплексних чисел, що стоять поруч:\n";
            for (int i = 0; i < moduli.Length; i++)
            {
                result += $"{moduli[i]}\n";
            }

            // Виводимо результат у Label
            labelResult.Text = result;
        }
    }

    public class ComplexArray
    {
        private Complex[] numbers;

        public ComplexArray(Complex[] numbers)
        {
            this.numbers = numbers;
        }

        public double[] GetAdjacentSumsModuli()
        {
            double[] moduli = new double[numbers.Length - 1];
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                moduli[i] = Complex.Abs(numbers[i] + numbers[i + 1]); // Обчислюємо модуль суми комплексних чисел, що стоять поруч
            }
            return moduli;
        }
    }
}

