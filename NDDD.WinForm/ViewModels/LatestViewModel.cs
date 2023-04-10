
using NDDD.Domain.Entities;
using NDDD.Domain.Repositories;
using NDDD.Infrastructure;
using System;

namespace NDDD.WinForm.ViewModels
{
    public class LatestViewModel : ViewModelBase
    {
        private IMeasureRepository _measureRepository;
        private string _areaIdText = string.Empty;
        private string _measureDateText = string.Empty;
        private string _measureValueText = string.Empty;

        /// <summary>
        /// 本番コード用
        /// </summary>
        public LatestViewModel()
            :this(Factories.CreateMeasure())
        {
        }

        /// <summary>
        /// テストコード用
        /// </summary>
        /// <param name="measureRepository"></param>
        public LatestViewModel(IMeasureRepository measureRepository)
        {
            _measureRepository = measureRepository;
        }

        public string AreaIdText 
        {
            get{ return _areaIdText; }
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
            var measure = _measureRepository.GetLatest();
            AreaIdText = measure?.AreaId.DisplayValue;
            MeasureDateText = measure?.MeasureDate.DisplayValue;
            MeasureValueText = Math.Round(measure.MeasureValue, 2) + "℃";
        }
    }
}
