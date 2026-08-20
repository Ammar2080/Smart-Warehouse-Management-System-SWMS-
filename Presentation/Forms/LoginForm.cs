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

        // Krypton UI controls initialization template for VS 2019 WinForms
        private void InitializeComponent()
        {
            this.SuspendLayout();
            
            // LoginForm properties
            this.ClientSize = new System.Drawing.Size(450, 300);
            this.Name = "LoginForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Smart Warehouse - Login";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.ResumeLayout(false);
        }

        private void BtnLogin_Click(object sender, EventArgs e, string username, string password)
        {
            try
            {
                User user = _userService.Login(username, password);
                LoggedInUser = user;
                MessageBox.Show($"Welcome, {user.FullName}!", "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
