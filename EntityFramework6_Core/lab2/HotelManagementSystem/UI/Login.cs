using System;
using System.Linq;
using System.Windows.Forms;
using HotelManagementSystem.Context.LoginManager;
using MetroFramework.Forms;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.UI
{
    public partial class Login : MetroForm
    {
        public Login()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void signinButton_Click(object sender, EventArgs e)
        {
            try
            {
                string username = usernameTextBox.Text.Trim();
                string password = passwordTextBox.Text.Trim();

                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    ShowMessage("Please enter username and password", "Validation");
                    return;
                }

                var role = Authenticate(username, password);

                if (role == "frontend")
                {
                    OpenForm(new Frontend());
                }
                else if (role == "kitchen")
                {
                    OpenForm(new Kitchen());
                }
                else
                {
                    HandleLoginFailure();
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, "Error");
            }
        }

        #region Authentication

        private string? Authenticate(string username, string password)
        {
            using var context = new LoginManagerContext();

            bool isFrontend = context.Frontends
                .AsNoTracking()
                .Any(u => u.UserName == username && u.Password == password);

            if (isFrontend) return "frontend";

            bool isKitchen = context.Kitchens
                .AsNoTracking()
                .Any(u => u.UserName == username && u.Password == password);

            if (isKitchen) return "kitchen";

            return null;
        }

        #endregion

        #region UI Helpers

        private void OpenForm(Form form)
        {
            this.Hide();
            form.Show();
        }

        private void HandleLoginFailure()
        {
            var choice = MessageBox.Show(
                this,
                "Username or Password is incorrect",
                "Login Failed",
                MessageBoxButtons.RetryCancel,
                MessageBoxIcon.Error);

            if (choice == DialogResult.Retry)
            {
                usernameTextBox.Clear();
                passwordTextBox.Clear();
                usernameTextBox.Focus();
            }
            else
            {
                Close();
            }
        }

        private void ShowMessage(string message, string title)
        {
            MessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        #endregion

        #region UI Events

        private void usernameTextBox_Click(object sender, EventArgs e)
        {
            usernameLabel.Visible = string.IsNullOrEmpty(usernameTextBox.Text);
        }

        private void passwordTextBox_Click(object sender, EventArgs e)
        {
            passwordLabel.Visible = string.IsNullOrEmpty(passwordTextBox.Text);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (!usernameLabel.Bounds.Contains(e.Location) && string.IsNullOrEmpty(usernameTextBox.Text))
                usernameLabel.Visible = false;

            if (!passwordLabel.Bounds.Contains(e.Location) && string.IsNullOrEmpty(passwordTextBox.Text))
                passwordLabel.Visible = false;
        }

        private void login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void LicenseCallButton_Click(object sender, EventArgs e)
        {
            new License().ShowDialog();
        }

        #endregion
    }
}