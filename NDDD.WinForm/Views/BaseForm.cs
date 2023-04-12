using NDDD.Domain;
using NDDD.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDDD.WinForm.Views
{
    /// <summary>
    /// Viewの基底クラス
    /// </summary>
    public partial class BaseForm : Form
    {
        /// <summary>
        /// ログ
        /// </summary>
        private static log4net.ILog _logger =
            log4net.LogManager.GetLogger(
                System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BaseForm()
        {
            InitializeComponent();

            toolStripStatusLabel1.Visible = false;

#if DEBUG
            toolStripStatusLabel1.Visible = true;
#endif

            UserIdLabel.Text = Shared.LoginId;
        }

        /// <summary>
        /// 例外共通処理。エラー処理の共通化(protectedなのはBaseFormを継承しているクラスからのみ呼び出すため)
        /// </summary>
        /// <param name="ex"></param>
        protected void ExceptionProc(Exception ex)
        {
            _logger.Error(ex.Message, ex);// 第2引数にインナーエクセプションも与えることができる

            MessageBoxIcon icon = MessageBoxIcon.Error;// デフォルト値指定
            string caption = "エラー";
            var exceptionBase = ex as ExceptionBase;
            // 変換できなかったらnull。もし意図的に出していない例外(ExceptionBaseに継承されている例外クラス以外の例外)が落ちてくるとnullになる
            if (exceptionBase != null)
            {
                if (exceptionBase.Kind == ExceptionBase.ExceptionKind.Info)
                {
                    icon = MessageBoxIcon.Information;
                    caption = "情報";
                }
                else if (exceptionBase.Kind == ExceptionBase.ExceptionKind.Warning)
                {
                    icon = MessageBoxIcon.Warning;
                    caption = "警告";
                }
            }
            MessageBox.Show(ex.Message, caption, MessageBoxButtons.OK, icon);

        }

        /// <summary>
        /// 起動時。BaseFormのロードイベント
        /// </summary>
        /// <param name="sender">コントロール</param>
        /// <param name="e">イベント引数</param>
        private void BaseForm_Load(object sender, EventArgs e)
        {
            _logger.Info("open" + this.Name);
        }

        /// <summary>
        /// 終了時。BaseFormのクローズイベント
        /// </summary>
        /// <param name="sender">コントロール</param>
        /// <param name="e">イベント引数</param>
        private void BaseForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _logger.Info("close" + this.Name);
        }
    }
}
