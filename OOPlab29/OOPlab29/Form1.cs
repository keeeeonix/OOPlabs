using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPlab29
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            loginButton.Enabled = true; // кнопка входу
            logoutButton.Enabled = false; // кнопка виходу
            sendButton.Enabled = false; // кнопка відправки
            chatTextBox.ReadOnly = true; // поле для повідомлень
            groupAddress = IPAddress.Parse(DEFAULT_HOST);
            localPort = DEFAULT_LOCALPORT;
            remotePort = DEFAULT_REMOTEPORT;
            host = DEFAULT_HOST;
            chatFont = chatTextBox.Font;
        }
        bool alive = false; // чи буде працювати потік для приймання
        UdpClient client;
        const int DEFAULT_LOCALPORT = 8001; // порт для приймання повідомлень
        const int DEFAULT_REMOTEPORT = 8001; // порт для передавання повідомлень
        const int TTL = 20;
        const string DEFAULT_HOST = "235.5.5.1"; // хост для групового розсилання
        IPAddress groupAddress; // адреса для групового розсилання
        string userName; // ім’я користувача в чаті
        int localPort;
        int remotePort;
        string host;
        Font chatFont;

        // метод приймання повідомлень
        private void ReceiveMessages()
        {
            alive = true;
            try
            {
                while (alive)
                {
                    IPEndPoint remoteIp = null;
                    byte[] data = client.Receive(ref remoteIp);
                    string message = Encoding.Unicode.GetString(data);
                    // додаємо отримане повідомлення в текстове поле
                    this.Invoke(new MethodInvoker(() =>
                    {
                        string time = DateTime.Now.ToShortTimeString();
                        chatTextBox.Text = time + " " + message + "\r\n" + chatTextBox.Text;
                        LogMessage(time + " " + message);
                    }));
                }
            }
            catch (ObjectDisposedException)
            {
                if (!alive)
                    return;
                throw;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // метод для запису повідомлень у лог-файл
        private void LogMessage(string message)
        {
            string logFilePath = Path.Combine(Application.StartupPath, "chat_log.txt");
            File.AppendAllText(logFilePath, message + Environment.NewLine);
        }


        // вихід з чату
        private void ExitChat()
        {
            string message = userName + " покидає чат";
            byte[] data = Encoding.Unicode.GetBytes(message);
            client.Send(data, data.Length, host, remotePort);
            client.DropMulticastGroup(groupAddress);
            alive = false;
            client.Close();
            loginButton.Enabled = true;
            logoutButton.Enabled = false;
            sendButton.Enabled = false;
            userNameTextBox.ReadOnly = false;
        }

        // обробник події закриття форми
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (alive)
                ExitChat();
        }

    private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void settingsButton_Click_1(object sender, EventArgs e)
        {
            using (SettingsForm settingsForm = new SettingsForm(localPort, remotePort, host, chatFont))
            {
                if (settingsForm.ShowDialog() == DialogResult.OK)
                {
                    localPort = settingsForm.LocalPort;
                    remotePort = settingsForm.RemotePort;
                    host = settingsForm.Host;
                    groupAddress = IPAddress.Parse(host);
                    chatFont = settingsForm.ChatFont;
                    chatTextBox.Font = chatFont;
                }
            }
        }

        private void loginButton_Click_1(object sender, EventArgs e)
        {

            userName = userNameTextBox.Text;
            userNameTextBox.ReadOnly = true;
            try
            {
                client = new UdpClient(localPort);
                // підключення до групового розсилання
                client.JoinMulticastGroup(groupAddress, TTL);

                // задача на приймання повідомлень
                Task receiveTask = new Task(ReceiveMessages);
                receiveTask.Start();
                // перше повідомлення про вхід нового користувача
                string message = userName + " увійшов до чату";
                byte[] data = Encoding.Unicode.GetBytes(message);
                client.Send(data, data.Length, host, remotePort);
                loginButton.Enabled = false;
                logoutButton.Enabled = true;
                sendButton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void sendButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                string message = String.Format("{0}: {1}", userName, messageTextBox.Text);
                byte[] data = Encoding.Unicode.GetBytes(message);
                client.Send(data, data.Length, host, remotePort);
                messageTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void logoutButton_Click_1(object sender, EventArgs e)
        {
            ExitChat();
        }
    }
}
