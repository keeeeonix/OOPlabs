using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPlab20
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                int Day = int.Parse(textBoxDay.Text);
                int Month = int.Parse(textBoxMonth.Text);
                int Year = int.Parse(textBoxYear.Text);

                int dayOfWeek = GetDayOfWeek(Day, Month, Year);

                string[] days = { "Понеділок", "Вівторок", "Середа", "Четвер", "П'ятниця", "Субота", "Неділя" };

                labelResult.Text = $"День тижня: {days[dayOfWeek]} ";
                if (Day > 31)
                {
                    MessageBox.Show("Помилка: Забагато днів в місяці.\n", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (Month > 12)
                {
                    MessageBox.Show("Помилка: Забагато місяців в році.\n", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(FormatException ex)
            {
                MessageBox.Show("Помилка: Введено неправильний формат числа.\n" + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: Непердбачена помилка.\n" + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static int GetDayOfWeek(int Day, int Month, int Year)
        {
            int d = Day;
            int m = Month;
            int y = Year;
            int dayOfWeek = (d + m + y + (y / 4)) % 7;

            return dayOfWeek;
        }
    }
}
