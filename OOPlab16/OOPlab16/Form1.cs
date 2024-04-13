using System;
using System.Numerics; // ��� ����������� �����
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

            // �������� ����� �������� ����������� ����� � ���������� ����
            string input = textBoxInput.Text;

            // ��������� �������� ����� �� ����� ��������� ����� �� ��������� ������
            string[] complexNumbersStrings = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            // ��������� ����� ����������� ����� ��� �������
            Complex[] complexNumbers = new Complex[complexNumbersStrings.Length];

            // ������� ������ ����� � ������������ ���� � ���������� �����
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
                    realPart = 0; // ����������, �� ������� ������� ������� 0, ���� ���� �� �������
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

            // ��������� ����� ��� ��������� ������ ��� ����������� �����, �� ������ �����
            double[] moduli = new double[complexNumbers.Length - 1];

            // ���������� ����� ��� ����������� �����, �� ������ �����
            for (int i = 0; i < moduli.Length; i++)
            {
                moduli[i] = Complex.Abs(complexNumbers[i] + complexNumbers[i + 1]);
            }

            // ������� ����� ��� ��������� ����������
            string result = "����� ��� ����������� �����, �� ������ �����:\n";
            for (int i = 0; i < moduli.Length; i++)
            {
                result += $"{moduli[i]}\n";
            }

            // �������� ��������� � Label
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
                moduli[i] = Complex.Abs(numbers[i] + numbers[i + 1]); // ���������� ������ ���� ����������� �����, �� ������ �����
            }
            return moduli;
        }
    }
}

