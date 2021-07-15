using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
            string str = "";
            Console.WriteLine("------------------------------\n"  + dice.roll("4d4!>3", out str));
            Console.WriteLine(str);*/
            
        }
    }
}
