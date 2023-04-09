using NDDD.Domain;

namespace NDDD.WinForm.Views
{
    public partial class LoginView : BaseForm
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, System.EventArgs e)
        {
            Shared.LoginId = LoginTextBox.Text;

            using (var f = new LatestView())
            {
                f.ShowDialog();
            }
        }
    }
}
