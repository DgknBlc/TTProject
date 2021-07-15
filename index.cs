using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTProject.src;

namespace TTProject
{
    public partial class index : Form
    {
        public index()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lbResult.Text = "Sonuç : ";
            string str = "";
            Dice dice = new Dice();
            List<int> list = new List<int>();
            int result = dice.diceRoll(txbDiceRoller.Text, out list, out str);

            lbResult.Text += result + "\n";
            lbResult.Text += "Anlanan : " + str + "\n";
            foreach (var item in list)
            {
                lbResult.Text += item + " ";
            }
        }
    }
}
