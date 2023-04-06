using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDD.Domain
{
    public static class Shared
    {
        public static bool IsFake { get; } =
            ConfigurationManager.AppSettings["IsFake"] == "1";
        public static string FakePath { get; } =
            ConfigurationManager.AppSettings["FakePath"];

    }
}
