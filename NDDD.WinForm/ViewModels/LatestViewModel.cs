
using NDDD.Domain.Entities;
using NDDD.Domain.Repositories;
using NDDD.Domain.StaticValues;
using NDDD.Domain.ValueObjects;
using NDDD.Infrastructure;
using System;
using System.Transactions;

namespace NDDD.WinForm.ViewModels
{
    /// <summary>
    /// 直近値のViewModel
    /// </summary>
    public class LatestViewModel : ViewModelBase
    {
        /// <summary>
        /// 計測リポジトリー
        /// </summary>
        private MeasureRepository _measureRepository;

        /// <summary>
        /// エリアID
        /// </summary>
        private string _areaIdText = string.Empty;

        /// <summary>
        /// 計測日時
        /// </summary>
        private string _measureDateText = string.Empty;

        /// <summary>
        /// 計測値
        /// </summary>
        private string _measureValueText = string.Empty;

        /// <summary>
        /// コンストラクタ。本番コード用
        /// </summary>
        public LatestViewModel()
            : this(Factories.CreateMeasure())
        {
        }

        /// <summary>
        /// コンストラクタ。テストコード用
        /// </summary>
        /// <param name="measureRepository"></param>
        public LatestViewModel(IMeasureRepository measureRepository)
        {
            _measureRepository = new MeasureRepository(measureRepository);
        }

        /// <summary>
        /// エリアID
        /// </summary>
        public string AreaIdText
        {
            get { return _areaIdText; }
            set
            {
                SetProperty(ref _areaIdText, value);    // プロパティに変更があった時のみ通知する
            }

        }

        /// <summary>
        /// 計測日時
        /// </summary>
        public string MeasureDateText
        {
            get { return _measureDateText; }
            set
            {
                SetProperty(ref _measureDateText, value);    // プロパティに変更があった時のみ通知する
            }
        }

        /// <summary>
        /// 計測値
        /// </summary>
        public string MeasureValueText
        {
            get { return _measureValueText; }
            set
            {
                SetProperty(ref _measureValueText, value);    // プロパティに変更があった時のみ通知する
            }
        }

        /// <summary>
        /// 検索
        /// </summary>
        public void Search()
        {
            //var measure = _measureRepository.GetLatest();
            // データベースからから最新の値をとらなくていい場合,タイマー10秒で常に取得してる値をとってくる
            var measure = Measures.GetLatest(new AreaId(20));
            AreaIdText = measure?.AreaId.DisplayValue;
            MeasureDateText = measure?.MeasureDate.DisplayValue;
            MeasureValueText = measure.MeasureValue.DisplayValue;
        }

        /// <summary>
        /// 保存
        /// </summary>
        public void Save()
        {
            using (var scope = new TransactionScope())
            {
                //ヘッダー
                //明細
                //在庫
                //履歴
                //顧客情報

                scope.Complete();
            }
        }
    }
}
