using RecipeWinForms.Properties;
using System.Configuration;

namespace RecipeWinForms
{
    public partial class frmLogin : Form
    {
        bool loginSuccess = false;
        public frmLogin()
        {
            InitializeComponent();
            btnLogin.Click += BtnLogin_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        public bool ShowLogin()
        {
            txtUserId.Text = Settings.Default.userId;
            this.ShowDialog();
            return loginSuccess;
        }

        private void BtnLogin_Click(object? sender, EventArgs e)
        {
            try
            {
                string env = "";

#if DEBUG
                env = "dev";
#else
                env = "live";
#endif

                string connString = ConfigurationManager.ConnectionStrings[env + "conn"].ConnectionString;

                DBManager.SetConnectionString(connString, true, txtUserId.Text, txtPassword.Text);
                Settings.Default.userId = txtUserId.Text;
                Settings.Default.Save();
                loginSuccess = true;
                Close();
            }
            catch
            {
                MessageBox.Show("Invalid login, Try again");
            }
        }

        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}
