using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using OOPlab25.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.OleDb;
using System.Diagnostics.Tracing;
using System.Drawing.Printing;

namespace OOPlab25
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            InitializeCustomComponents();
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ivano\source\repos\OOPlab25\kindergarden.accdb;";
            connection = new OleDbConnection(connectionString);
        }
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtChildName.Text))
            {
                MessageBox.Show("Please enter child name.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtGuardianName.Text))
            {
                MessageBox.Show("Please enter guardian name.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtGuardianPhone.Text))
            {
                MessageBox.Show("Please enter guardian phone.");
                return false;
            }
            return true;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return; 
            }
            string childName = txtChildName.Text;
            string guardianName = txtGuardianName.Text;
            string guardianPhone = txtGuardianPhone.Text;
            DateTime birthDate = dtpBirthDate.Value;

            string query = "INSERT INTO garden (ChildName, GuardianName, GuardianPhone, BirthDate) VALUES (?, ?, ?, ?)";

            using (OleDbCommand command = new OleDbCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ChildName", childName);
                command.Parameters.AddWithValue("@GuardianName", guardianName);
                command.Parameters.AddWithValue("@GuardianPhone", guardianPhone);
                command.Parameters.AddWithValue("@BirthDate", birthDate);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Record added successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        private void btnReportByAge_Click(object sender, EventArgs e)
        {
            listBoxResults.Items.Clear();
            string query = "SELECT ChildName, GuardianName, GuardianPhone, BirthDate FROM garden WHERE YEAR(BirthDate) = ?";
            using (OleDbCommand command = new OleDbCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Year", DateTime.Now.Year - int.Parse(txtAge.Text));
                connection.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listBoxResults.Items.Add($"{reader["ChildName"]}, {reader["GuardianName"]}, {reader["GuardianPhone"]}, {reader["BirthDate"]}");
                    }
                }
                connection.Close();
            }
        }
        private void btnReportByGuardian_Click(object sender, EventArgs e)
        {
            listBoxResults.Items.Clear();
            string query = "SELECT ChildName, BirthDate FROM garden WHERE GuardianName = ?";
            using (OleDbCommand command = new OleDbCommand(query, connection))
            {
                command.Parameters.AddWithValue("@GuardianName", txtReportGuardianName.Text);
                connection.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listBoxResults.Items.Add($"{reader["ChildName"]}, {reader["BirthDate"]}");
                    }
                }
                connection.Close();
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            listBoxResults.Items.Clear();
            string query = "SELECT ChildName, GuardianName, GuardianPhone, BirthDate FROM garden WHERE ChildName LIKE ?";
            using (OleDbCommand command = new OleDbCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ChildName", "%" + txtSearch.Text + "%");
                connection.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listBoxResults.Items.Add($"{reader["ChildName"]}, {reader["GuardianName"]}, {reader["GuardianPhone"]}, {reader["BirthDate"]}");
                    }
                }
                connection.Close();
            }
        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
