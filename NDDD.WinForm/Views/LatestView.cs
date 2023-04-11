using NDDD.Domain.Exceptions;
using NDDD.Infrastructure;
using NDDD.Infrastructure.Fake;
using NDDD.WinForm.ViewModels;
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
    public partial class LatestView : BaseForm
    {
        private LatestViewModel _viewModel = new LatestViewModel();
        public LatestView()
        {
            InitializeComponent();


            AreaIdTextBox.DataBindings.Add(
                "Text",
                _viewModel,
                nameof(_viewModel.AreaIdText));
            MeasureDateTextBox.DataBindings.Add(
                "Text",
                _viewModel,
                nameof(_viewModel.MeasureDateText));
            MeasureValueTextBox.DataBindings.Add(
                "Text",
                _viewModel,
                nameof(_viewModel.MeasureValueText));
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                _viewModel.Search();
            }
            catch (Exception ex)
            {
                MessageBoxIcon icon = MessageBoxIcon.Error;// デフォルト値指定
                string caption = "エラー";
                var exceptionBase = ex as ExceptionBase;
                // 変換できなかったらnull。もし意図的に出していない例外(ExceptionBaseに継承されている例外クラス以外の例外)が落ちてくるとnullになる
                if(exceptionBase != null)
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
        }
    }
}
