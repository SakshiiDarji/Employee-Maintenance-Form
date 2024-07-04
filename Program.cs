using Lab1_ConnectedMode.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1_ConnectedMode.BLL;
using System.Windows.Forms;

namespace Lab1_ConnectedMode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FormTest());
            Application.Run(new FormEmployee());
        }
    }
}
