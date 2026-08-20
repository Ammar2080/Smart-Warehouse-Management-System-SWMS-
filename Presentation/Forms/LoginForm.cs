using System;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using WarehouseManagement.BusinessLogic;
using WarehouseManagement.Models;

namespace WarehouseManagement.Presentation.Forms
{
    public partial class LoginForm : KryptonForm
    {
        private readonly UserService _userService;
        public User LoggedInUser { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
            _userService = new UserService();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            try
            {
                User user = _userService.Login(username, password);
                if (user != null)
                {
                    LoggedInUser = user;
                    KryptonMessageBox.Show($"مرحباً بك، {user.FullName}!", "تسجيل الدخول ناجح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "خطأ في تسجيل الدخول", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
