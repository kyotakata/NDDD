using NDDD.Domain.StaticValues;
using NDDD.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NDDD.WinForm.BackgroundWorkers
{
    internal static class LatestTimer
    {
        private static System.Threading.Timer _timer;
        private static bool _isWork = false;

        static LatestTimer()
        {
            _timer = new Timer(Callback);
        }

        internal static void Start()
        {
            _timer.Change(0, 10000);
            // 引数1：スタートの何秒後に動作させるか
            // 引数2：何秒間隔で動作させるか
        }

        internal static void Stop()
        {
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
        }

        private static void Callback(object o)
        {
            if (_isWork)
            {
                return;
            }


            try
            {
                _isWork = true;
                //何か処理する
                Measures.Create(Factories.CreateMeasure());
            }
            finally
            {
                // 最後に必ずfalse
                _isWork = false;
            }
        }
    }
}
