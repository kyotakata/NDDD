
using NDDD.Domain.Entities;
using NDDD.Domain.Repositories;
using NDDD.Domain.StaticValues;
using NDDD.Domain.ValueObjects;
using NDDD.Infrastructure;
using System;

namespace NDDD.WinForm.ViewModels
{
    public class LatestViewModel : ViewModelBase
    {
        private MeasureRepository _measureRepository;
        private string _areaIdText = string.Empty;
        private string _measureDateText = string.Empty;
        private string _measureValueText = string.Empty;

        /// <summary>
        /// 本番コード用
        /// </summary>
        public LatestViewModel()
            : this(Factories.CreateMeasure())
        {
        }

        /// <summary>
        /// テストコード用
        /// </summary>
        /// <param name="measureRepository"></param>
        public LatestViewModel(IMeasureRepository measureRepository)
        {
            _measureRepository = new MeasureRepository(measureRepository);
        }

        public string AreaIdText
        {
            get { return _areaIdText; }
            set
            {
                SetProperty(ref _areaIdText, value);    // プロパティに変更があった時のみ通知する
            }

        }
        public string MeasureDateText
        {
            get { return _measureDateText; }
            set
            {
                SetProperty(ref _measureDateText, value);    // プロパティに変更があった時のみ通知する
            }
        }
        public string MeasureValueText
        {
            get { return _measureValueText; }
            set
            {
                SetProperty(ref _measureValueText, value);    // プロパティに変更があった時のみ通知する
            }
        }

        public void Search()
        {
            //var measure = _measureRepository.GetLatest();
            // データベースからから最新の値をとらなくていい場合,タイマー10秒で常に取得してる値をとってくる
            var measure = Measures.GetLatest(new AreaId(20));
            AreaIdText = measure?.AreaId.DisplayValue;
            MeasureDateText = measure?.MeasureDate.DisplayValue;
            MeasureValueText = measure.MeasureValue.DisplayValue;
        }
    }
}
