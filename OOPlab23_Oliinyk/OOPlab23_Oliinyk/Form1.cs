using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPlab23_Oliinyk
{
    public partial class Form1 : Form
    {
        private float[] X;
        private float[] Y;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Paint += new PaintEventHandler(Form1_Paint);
        }

        private void buttonDraw_Click(object sender, EventArgs e)
        {
            try
            {
                // Зчитування коефіцієнтів з текстових полів
                float a = float.Parse(textBoxA.Text);
                float b = float.Parse(textBoxB.Text);
                float c = float.Parse(textBoxC.Text);

                // Обчислення точок
                CalculatePoints(a, b, c);

                // Перемалювати форму
                this.Invalidate();
            }
            catch (FormatException)
            {
                MessageBox.Show("Введіть правильні значення коефіцієнтів.");
            }
        }

        private void CalculatePoints(float a, float b, float c)
        {
            int pointsCount = 1000;
            X = new float[pointsCount];
            Y = new float[pointsCount];

            float tMin = -5f;
            float tMax = 5f;
            float step = (tMax - tMin) / pointsCount;

            for (int i = 0; i < pointsCount; i++)
            {
                float t = tMin + i * step;
                X[i] = a * t * t * (float)Math.Sin(t); // Змінити на вашу функцію
                Y[i] = b * t * (float)Math.Pow(Math.Cos(t), 2) + c; // Змінити на вашу функцію
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawGraph(e.Graphics);
        }

        private void DrawGraph(Graphics g)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Pen pen = new Pen(Color.Blue, 2);

            // Центр форми
            int centerX = this.ClientSize.Width / 2;
            int centerY = this.ClientSize.Height / 2;

            // Масштабування графіка для кращого відображення
            float scaleX = 20;
            float scaleY = 20;

            // Малюємо осі
            g.DrawLine(Pens.Black, centerX, 0, centerX, this.ClientSize.Height); // вісь Y
            g.DrawLine(Pens.Black, 0, centerY, this.ClientSize.Width, centerY); // вісь X

            // Підписи осей
            Font font = new Font("Arial", 10);
            Brush brush = Brushes.Black;
            g.DrawString("X", font, brush, this.ClientSize.Width - 20, centerY + 5);
            g.DrawString("Y", font, brush, centerX + 5, 5);

            // Значення на осях
            for (int i = -5; i <= 5; i++)
            {
                g.DrawString(i.ToString(), font, brush, centerX + 5, centerY - i * scaleY);
                g.DrawString(i.ToString(), font, brush, centerX + i * scaleX, centerY + 5);
            }

            // Малюємо точки графіка
            if (X != null && Y != null && X.Length == Y.Length)
            {
                // Малюємо точки графіка
                for (int i = 0; i < X.Length - 1; i++)
                {
                    float x1 = centerX + X[i] * scaleX;
                    float y1 = centerY - Y[i] * scaleY;
                    float x2 = centerX + X[i + 1] * scaleX;
                    float y2 = centerY - Y[i + 1] * scaleY;

                    g.DrawLine(pen, x1, y1, x2, y2);
                }
            }
            pen.Dispose();
        }        
    }
}
