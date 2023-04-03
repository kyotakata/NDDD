using Microsoft.VisualStudio.TestTools.UnitTesting;
using NDDD.WinForm.ViewModels;
using System;

namespace NDDDTest.Tests.ViewModelTests
{
    [TestClass]
    public class LatestViewModelTest
    {
        [TestMethod]
        public void シナリオ()
        {
            var vm = new LatestViewModel();
            //エリアID
            //計測日時
            //計測値

            vm.Search();
            vm.AreaIdText.Is("0001");
            vm.MeasureDateText.Is("2012/12/12 12:34:56");
            vm.MeasureValueText.Is("12.34℃");
        }
    }
}
