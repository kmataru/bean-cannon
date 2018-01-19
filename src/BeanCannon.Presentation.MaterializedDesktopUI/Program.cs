using BeanCannon.Presentation.MaterializedDesktopUI.Forms;
using System;
using System.Windows.Forms;

namespace BeanCannon.Presentation.MaterializedDesktopUI
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
