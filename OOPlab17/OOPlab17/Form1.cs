using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPlab17
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        // Абстрактний клас Pair з віртуальними арифметичними операціями
        abstract class Pair
        {
            // Віртуальні методи для арифметичних операцій
            public abstract Pair Add(Pair other);
            public abstract Pair Subtract(Pair other);
            public abstract Pair Multiply(Pair other);
            public abstract Pair Divide(Pair other);
        }

        // Клас Money як похідний від Pair
        class Money : Pair
        {
            long grivnas; // Гривні (довге ціле)
            byte kopiyky; // Копійки (байт)

            // Конструктор класу Money
            public Money(long grivnas, byte kopiyky)
            {
                this.grivnas = grivnas;
                this.kopiyky = kopiyky;
            }

            // Реалізація віртуальних методів арифметичних операцій
            public override Pair Add(Pair other)
            {
                if (other is Money)
                {
                    Money otherMoney = (Money)other;
                    long resultGrivnas = this.grivnas + otherMoney.grivnas;
                    byte resultKopiyky = (byte)(this.kopiyky + otherMoney.kopiyky);
                    return new Money(resultGrivnas, resultKopiyky);
                }
                throw new ArgumentException("Помилка: неможливо додати Money до іншого типу.");
            }

            public override Pair Subtract(Pair other)
            {
                if (other is Money)
                {
                    Money otherMoney = (Money)other;
                    long resultGrivnas = this.grivnas - otherMoney.grivnas;
                    byte resultKopiyky = (byte)(this.kopiyky - otherMoney.kopiyky);
                    return new Money(resultGrivnas, resultKopiyky);
                }
                throw new ArgumentException("Помилка: неможливо відняти Money від іншого типу.");
            }

            public override Pair Multiply(Pair other)
            {
                throw new NotImplementedException("Множення грошової одиниці на іншу грошову одиницю не підтримується.");
            }

            public override Pair Divide(Pair other)
            {
                throw new NotImplementedException("Ділення грошової одиниці на іншу грошову одиницю не підтримується.");
            }
        }

        // Клас Complex як похідний від Pair
        class Complex : Pair
        {
            double real; // Дійсна частина
            double imaginary; // Уявна частина

            // Конструктор класу Complex
            public Complex(double real, double imaginary)
            {
                this.real = real;
                this.imaginary = imaginary;
            }

            // Реалізація віртуальних методів арифметичних операцій
            public override Pair Add(Pair other)
            {
                if (other is Complex)
                {
                    Complex otherComplex = (Complex)other;
                    double resultReal = this.real + otherComplex.real;
                    double resultImaginary = this.imaginary + otherComplex.imaginary;
                    return new Complex(resultReal, resultImaginary);
                }
                throw new ArgumentException("Помилка: неможливо додати Complex до іншого типу.");
            }

            public override Pair Subtract(Pair other)
            {
                if (other is Complex)
                {
                    Complex otherComplex = (Complex)other;
                    double resultReal = this.real - otherComplex.real;
                    double resultImaginary = this.imaginary - otherComplex.imaginary;
                    return new Complex(resultReal, resultImaginary);
                }
                throw new ArgumentException("Помилка: неможливо відняти Complex від іншого типу.");
            }

            public override Pair Multiply(Pair other)
            {
                if (other is Complex)
                {
                    Complex otherComplex = (Complex)other;
                    double resultReal = (this.real * otherComplex.real) - (this.imaginary * otherComplex.imaginary);
                    double resultImaginary = (this.real * otherComplex.imaginary) + (this.imaginary * otherComplex.real);
                    return new Complex(resultReal, resultImaginary);
                }
                throw new ArgumentException("Помилка: неможливо помножити Complex на інший тип.");
            }

            public override Pair Divide(Pair other)
            {
                throw new NotImplementedException("Ділення комплексного числа на інше комплексне число не підтримується.");
            }
        }
    }
}
