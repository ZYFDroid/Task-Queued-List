using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TQL
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Process mypid = Process.GetCurrentProcess();
            IEnumerable<Process> pc = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(Application.ExecutablePath)).Where(pcs =>pcs.MainModule.FileName == mypid.MainModule.FileName && pcs.Id !=mypid.Id);
            if (pc.Count() > 0) {
                pc.ToList().ForEach(p => p.Kill());
                Properties.Settings.Default.windowPosition = new System.Drawing.Point(0,0);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Environment.CurrentDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            Application.Run(new Form1());
        }
    }
}
