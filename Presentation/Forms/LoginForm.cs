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

        private void BtnLogin_Click(object sender, EventArgs e, string username, string password)
        {
            try
            {
                User user = _userService.Login(username, password);
                LoggedInUser = user;
                KryptonMessageBox.Show($"Welcome, {user.FullName}!", "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
