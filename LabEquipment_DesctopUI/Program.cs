using System;
using System.Windows.Forms;

namespace LabEquipment.DesctopUI
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
            Application.ThreadException += Application_ThreadException;

            AuthenticationWindow authenticationWnd = new AuthenticationWindow();
            if (authenticationWnd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            Application.Run(new MainForm());
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "E R R O R !", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
