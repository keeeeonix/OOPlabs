using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPlab19
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void OutputTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ProcessButton_Click(object sender, EventArgs e)
        {
            string input = InputTextBox.Text;
            string output = ReplaceConsecutiveCharacters(input);
            OutputTextBox.Text = output;
        }

        private string ReplaceConsecutiveCharacters(string input)
        {
            StringBuilder result = new StringBuilder();
            int count = 1;

            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == input[i + 1])
                {
                    count++;
                }
                else
                {
                    result.Append(input[i]);
                    if (count > 1)
                    {
                        result.Append(count);
                    }
                    count = 1;
                }
            }

            // Додати останній символ та кількість, якщо вони існують
            result.Append(input[input.Length - 1]);
            if (count > 1)
            {
                result.Append(count);
            }

            return result.ToString();
        }
    }
}
