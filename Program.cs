using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTProject.src;

namespace TTProject
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new index());
            /*Dice dice = new Dice();
            List<int> values;
            Console.WriteLine(dice.diceRoll("6d8!kh3", out values));
            String txt = "[";
            foreach (var value in values)
            {
                txt += value + " ";
            }
            txt += "]";
            Console.WriteLine(txt);*/
            
        }
    }
}
