using System;
using System.Windows.Forms;

namespace MyLibrary
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        
        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        
        private void btnLogin_Click(object sender, EventArgs e)
        {
          
            if (AuthenticateUser(txtusername.Text.Trim(), txtPassword.Text))
            {
                
                MessageBox.Show("Login successful!", "Success",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                MainForm mainForm = new MainForm();
                mainForm.FormClosed += (s, args) => this.Close(); // Close login form when main form closes
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password!", "Login Failed",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtusername.Focus();
            }
        }

        private bool AuthenticateUser(string username, string password)
        {
            return username == "ftalew" && password == "1234";
        }
        private void label_Click(object sender, EventArgs e)
        {
            
        }

        private void lblpassword_Click(object sender, EventArgs e)
        {
           
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}