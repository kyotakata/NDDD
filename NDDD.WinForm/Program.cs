using NDDD.WinForm.Views;
using System;
using System.Windows.Forms;

namespace NDDD.WinForm
{
    internal static class Program
    {
        private static log4net.ILog _logger =
           log4net.LogManager.GetLogger(
               System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // ログにはレベルがある(Degug,Info,Warn,Error,Fatal)
            _logger.Debug("デバッグのログ");
            _logger.Info("インフォのログ");
            _logger.Warn("警告のログ");
            _logger.Error("エラーのログ");
            _logger.Fatal("致命的なログ");

            Application.Run(new LoginView());// この行でアプリケーションが始まる
        }
    }
}
