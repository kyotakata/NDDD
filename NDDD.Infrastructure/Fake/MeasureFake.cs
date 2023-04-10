using NDDD.Domain;
using NDDD.Domain.Entities;
using NDDD.Domain.Exceptions;
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
        public MeasureEntity GetLatest()
        {

            try
            {
                var lines = System.IO.File.ReadAllLines(
                    Shared.FakePath + @"\" + "MeasureFake.csv"); // ファイル名はクラス名.拡張子
                var value = lines[0].Split(','/*値にカンマはない想定*/);    // 1件目だけとる
                return new MeasureEntity(
                    Convert.ToInt32(value[0]),
                    Convert.ToDateTime(value[1]),
                    Convert.ToSingle(value[2]));
            }
            catch(Exception ex)
            {
                // ファイルがない場合はCatchした値が画面にデフォルトで出るようにする
                throw new FakeException(
                    "MeasureFakeの取得に失敗しました",
                    ex);
                
                //return new MeasureEntity(
                //    10,
                //    Convert.ToDateTime("2020/12/12 12:34:56"),
                //    123.341f);
            }
        }
    }
}
