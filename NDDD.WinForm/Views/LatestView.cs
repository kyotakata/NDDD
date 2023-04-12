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
    /// <summary>
    /// 直近値View
    /// </summary>
    public partial class LatestView : BaseForm
    {
        /// <summary>
        /// ViewModel
        /// </summary>
        private LatestViewModel _viewModel = new LatestViewModel();
        
        /// <summary>
        /// コンストラクタ
        /// </summary>
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

        /// <summary>
        /// 検索ボタンクリックイベント
        /// </summary>
        /// <param name="sender">コントロール</param>
        /// <param name="e">イベント引数</param>
        private void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                _viewModel.Search();
            }
            catch (Exception ex)
            {
                ExceptionProc(ex);
            }
        }
    }
}
