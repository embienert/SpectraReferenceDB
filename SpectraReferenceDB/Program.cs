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
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            ReferenceFile file = ReferenceFile.FromSpc(@"C:\Users\marti\source\repos\SpectraReferenceDB\SpectraReferenceDB\data\Cyclohexane_beforeCalib_max_5x5s_50mW_210518.spc");

            Console.WriteLine(file.ToString());
        }
    }
}
