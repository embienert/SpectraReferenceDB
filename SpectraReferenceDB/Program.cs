using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpectraReferenceDB
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());

            //Reference file = Reference.FromSpc(@"C:\Users\marti\source\repos\SpectraReferenceDB\SpectraReferenceDB\data\Cyclohexane_230220_Cal_check.spc");

            //Console.WriteLine(file.ToString());
        }
    }
}
