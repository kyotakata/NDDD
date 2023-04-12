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
    /// <summary>
    /// 直近値のタイマー
    /// </summary>
    internal static class LatestTimer
    {
        /// <summary>
        /// タイマー。バックグラウンドで常時動かすのであればSystem.Threading.Timerを使用。
        /// 画面の中で同期的に使うのであればWindows.Timerを使用。
        /// </summary>
        private static System.Threading.Timer _timer;

        /// <summary>
        /// 処理中の時true
        /// </summary>
        private static bool _isWork = false;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        static LatestTimer()
        {
            _timer = new Timer(Callback);
        }

        /// <summary>
        /// スタート
        /// </summary>
        internal static void Start()
        {
            _timer.Change(0, 10000);
            // 引数1：スタートの何秒後に動作させるか
            // 引数2：何秒間隔で動作させるか
        }

        /// <summary>
        /// ストップ
        /// </summary>
        internal static void Stop()
        {
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
        }

        /// <summary>
        /// コールバック
        /// </summary>
        /// <param name="o"></param>
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
