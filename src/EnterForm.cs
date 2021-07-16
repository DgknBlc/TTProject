using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTProject.src
{
    public partial class EnterForm : Form
    {
        public EnterForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Server server = new Server(Int16.Parse(txbPort.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChatForm chatForm = new ChatForm();
            this.Visible = true;
            chatForm.ShowDialog();
        }
    }
}
