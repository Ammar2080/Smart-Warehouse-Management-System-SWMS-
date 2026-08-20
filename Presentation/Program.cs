using System;
using System.Windows.Forms;
using WarehouseManagement.Presentation.Forms;

namespace WarehouseManagement.Presentation
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK && loginForm.LoggedInUser != null)
            {
                Application.Run(new MainForm(loginForm.LoggedInUser));
            }
        }
    }
}
