using System;
using System.Windows.Forms;
using System.Runtime.Versioning;

namespace Heiner
{
    [SupportedOSPlatform("windows")]
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
