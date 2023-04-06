using NDDD.Domain.Entities;
using NDDD.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDD.Infrastructure.Fake
{
    internal class MeasureFake : IMeasureRepository
    {
        internal const string FakePath = @"C:\Users\kyota\source\repos\NDDD\NDDD.Infrastructure\NDDDFake\";
        public MeasureEntity GetLatest()
        {

            try
            {
                var lines = System.IO.File.ReadAllLines(
                    FakePath + "MeasureFake.csv"); // ファイル名はクラス名.拡張子
                var value = lines[0].Split(','/*値にカンマはない想定*/);    // 1件目だけとる
                return new MeasureEntity(
                    Convert.ToInt32(value[0]),
                    Convert.ToDateTime(value[1]),
                    Convert.ToSingle(value[2]));
            }
            catch
            {
                // ファイルがない場合はCatchした値が画面にデフォルトで出るようにする
                return new MeasureEntity(
                    10,
                    Convert.ToDateTime("2020/12/12 12:34:56"),
                    123.341f);
            }
        }
    }
}
