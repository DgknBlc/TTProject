using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTProject.src;

namespace TTProject
{
    public partial class ChatForm : Form
    {
        string readData = null;
        Thread th;
        private TcpClient socket;
        private Stream stream;
        public ChatForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Send(textBox3.Text);
            textBox3.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                socket = new TcpClient("25.75.178.110", 8888);
                stream = socket.GetStream();
                Send(textBox1.Text);
                th = new Thread(Run);
                th.Start();
                //groupBox1.Visible = false;
            }
            catch (IOException) { }
            catch (ObjectDisposedException) { }
            catch (SocketException) { MessageBox.Show("Bağlantı sağlanamadı"); }
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            AcceptButton = this.button2;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            AcceptButton = this.button1;
        }

        private void ChatForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseConnection();
        }

        public void Send(string message)
        {
            byte[] buffer = Encoding.Unicode.GetBytes(message);
            stream.Write(buffer, 0, buffer.Length);
        }

        public void Run()
        {
            byte[] buffer = new byte[2048];
            try
            {
                while (true)
                {
                    int receivedBytes = stream.Read(buffer, 0, buffer.Length);
                    if (receivedBytes < 1)
                        break;
                    string message = Encoding.Unicode.GetString(buffer, 0, receivedBytes);
                    readData = message;
                    msg();
                }
            }
            catch (IOException) { }
            catch (ObjectDisposedException) { }
            CloseConnection();
            Environment.Exit(0);
        }

        public void CloseConnection()
        {
            Console.WriteLine("Soket kapatıldı.");
            try
            {
                if (th != null)
                    th.Abort();
                socket.Close();
            }
            catch (Exception){ }
            
        }

        private void msg()
        {
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(msg));
            else 
            {
                textBox2.Text = textBox2.Text + Environment.NewLine + " >> " + readData;
                textBox2.SelectionStart = textBox2.Text.Length;
                textBox2.ScrollToCaret();
            }
        }
    }
}
