using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;
using System.Text.RegularExpressions;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            double x;
            double y;
            double result;
            try
            {
                x = Convert.ToDouble(Xvalue.Text);
                y = Convert.ToDouble(Yvalue.Text);
                result = Math.Pow(2, x * -1) - Math.Cos(x) + Math.Sin(2 * x * y);
                label3.Text = result.ToString("n");
            } catch { 
                btn.Focus();
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            double a;
            double b;
            double c;
            double al;
            double be;
            double g;
            double r;
            double result1;
            double result2;
            double result3;
            try
            {
                a = Convert.ToDouble(alphaValue.Text);
                b = Convert.ToDouble(betaValue.Text);
                c = Convert.ToDouble(gammaValue.Text);
                r = Convert.ToDouble(Rvalue.Text);
                al = a / 57.296;
                be = b / 57.296;
                g = c / 57.296;
                result1 = 2 * r * Math.Sin(al);
                result2 = 2 * r * Math.Sin(be);
                result3 = 2 * r * Math.Sin(g);
                label8.Text = result1.ToString("n") + " " + result2.ToString("n") + " " + result3.ToString("n");
            }
            catch
            {
                btn2.Focus();

            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            double x1;
            double y1;
            double x2; 
            double y2;
            double x;
            double y;
            x1 = Convert.ToDouble(BL1border.Text);
            y1 = Convert.ToDouble(BL2border.Text);
            x2 = Convert.ToDouble(TR1border.Text);
            y2 = Convert.ToDouble(TR2border.Text);
            x = Convert.ToDouble(axis1.Text);
            y = Convert.ToDouble(axis2.Text);
            try
            {
                if(x >= x1 && x <= x2 && y >= y1 && y <= y2)
                {
                    label13.Text = "True";
                } else
                {
                    label13.Text = "False";
                }
            }catch
            {
                btn3.Focus();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double x;
            double ln;
            double cos;
            double sin;
            double result;
            x = Convert.ToDouble(Vvalue.Text);
            try
            {
                ln = Math.Log(x);
                cos = Math.Cos(x);
                sin = Math.Sin(x);
                if(ln != null && cos != null && sin != null)
                {
                    List<double> list = new List<double>
                   {
                       ln, cos, sin
                   };
                    list.Sort();

                    string sortedList = string.Join(Environment.NewLine, list);

                    label17.Text = sortedList;
                }
            }catch
            {
                btn4.Focus();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Отримуємо значення n та k з текстових полів
            if (int.TryParse(Nvalue.Text, out int n) && int.TryParse(Kvalue.Text, out int k))
            {
                // Перевіряємо, чи дорівнює число n сумі k-x степенів своїх цифр
                bool result = IsDigitPowerSum(n, k);

                // Виводимо результат у відповідний label
                result5.Text = result ? "Так" : "Ні";
            }
            else
            {
                MessageBox.Show("Будь ласка, введіть коректні значення для n та k.");
            }
        }

        private bool IsDigitPowerSum(int n, int k)
        {
            // Перетворюємо число n в рядок, щоб розбити його на цифри
            string nAsString = n.ToString();

            // Обчислюємо суму k-x степенів цифр числа n
            int sum = nAsString.Sum(c => (int)Math.Pow(char.GetNumericValue(c), k));

            // Перевіряємо, чи дорівнює отримана сума числу n
            return sum == n;
        }

        private void button2_Click(object sender, EventArgs e)
        { 
            if (int.TryParse(Avalue.Text, out int A) && int.TryParse(Bvalue.Text, out int B))
            {
                int[] weatherForecast = new int[30];
                TextBox[] weatherTextBoxes = new TextBox[30];
                weatherTextBoxes[0] = day1TextBox;
                weatherTextBoxes[1] = day2TextBox;
                weatherTextBoxes[2] = day3TextBox;
                weatherTextBoxes[3] = day4TextBox;
                weatherTextBoxes[4] = day5TextBox;
                weatherTextBoxes[5] = day6TextBox;
                weatherTextBoxes[6] = day7TextBox;
                weatherTextBoxes[7] = day8TextBox;
                weatherTextBoxes[8] = day9TextBox;
                weatherTextBoxes[9] = day10TextBox;
                weatherTextBoxes[10] = day11TextBox;
                weatherTextBoxes[11] = day12TextBox;
                weatherTextBoxes[12] = day13TextBox;
                weatherTextBoxes[13] = day14TextBox;
                weatherTextBoxes[14] = day15TextBox;
                weatherTextBoxes[15] = day16TextBox;
                weatherTextBoxes[16] = day17TextBox;
                weatherTextBoxes[17] = day18TextBox;
                weatherTextBoxes[18] = day19TextBox;
                weatherTextBoxes[19] = day20TextBox;
                weatherTextBoxes[20] = day21TextBox;
                weatherTextBoxes[21] = day22TextBox;
                weatherTextBoxes[22] = day23TextBox;
                weatherTextBoxes[23] = day24TextBox;
                weatherTextBoxes[24] = day25TextBox;
                weatherTextBoxes[25] = day26TextBox;
                weatherTextBoxes[26] = day27TextBox;
                weatherTextBoxes[27] = day28TextBox;
                weatherTextBoxes[28] = day29TextBox;
                weatherTextBoxes[29] = day30TextBox;
                // Читаємо відомості про погоду з текстових полів та заповнюємо масив
                for (int i = 0; i < 30; i++)
                {
                    if (day1TextBox.Text == "1")
                        weatherForecast[i] = 1;
                    else if (day1TextBox.Text == "0")
                        weatherForecast[i] = 0;
                    else
                    {
                        MessageBox.Show("Будь ласка, введіть 1 або 0 для погоди на кожний день.");
                        return;
                    }
                }

                // Обчислюємо місце розташування равлика після 30 днів спостереження
                int finalPosition = CalculateSnailPosition(A, B, weatherForecast);

                // Виводимо результат у відповідний label
                result6.Text = $"Місце розташування равлика після 30-го дня: {finalPosition} см";
            }
            else
            {
                MessageBox.Show("Будь ласка, введіть коректні значення для A та B.");
            }
        }

        private int CalculateSnailPosition(int A, int B, int[] weatherForecast)
        {
            int currentPosition = A; // Початкове положення равлика

            // Проходимо через кожен день спостереження
            for (int i = 0; i < 30; i++)
            {
                if (weatherForecast[i] == 1) // Сонячний день
                {
                    currentPosition += 2; // Равлик піднімається на 2 см
                }
                else // Похмурий день
                {
                    currentPosition -= 1; // Равлик опускається на 1 см
                }

                // Перевіряємо, чи равлик залишається на дереві
                if (currentPosition <= 0)
                {
                    return 0; // Якщо равлик впав на землю, повертаємо 0
                }
                else if (currentPosition >= B * 100) // Переводимо в сантиметри, якщо B введено в метрах
                {
                    return B * 100; // Якщо равлик дійшов до вершини дерева, повертаємо висоту дерева
                }
            }

            return currentPosition;
        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        { 
        string input = inputTextBox.Text; // Отримуємо рядок з текстового поля

        // Викликаємо функцію для знаходження найбільшої послідовності цифр
        int longestSequenceLength = FindLongestDigitSequence(input);

        // Виводимо результат на екран у відповідний label
        result7.Text = $"Довжина найбільшої послідовності цифр: {longestSequenceLength}";
        }

    private int FindLongestDigitSequence(string input)
    {
        int maxLength = 0;
        int currentLength = 0;

        // Використовуємо регулярний вираз для знаходження послідовностей цифр у рядку
        foreach (Match match in Regex.Matches(input, @"\d+"))
        {
            // Обчислюємо довжину поточної послідовності цифр
            currentLength = match.Length;

            // Оновлюємо максимальну довжину, якщо поточна більша
            if (currentLength > maxLength)
            {
                maxLength = currentLength;
            }
        }

        return maxLength;
    }
}
}
