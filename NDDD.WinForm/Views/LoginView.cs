using NDDD.Domain;

namespace NDDD.WinForm.Views
{
    /// <summary>
    /// ログインView
    /// </summary>
    public partial class LoginView : BaseForm
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public LoginView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ログインボタン
        /// </summary>
        /// <param name="sender">コントロール</param>
        /// <param name="e">イベント引数</param>
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
