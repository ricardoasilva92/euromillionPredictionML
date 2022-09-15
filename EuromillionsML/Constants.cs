using System;
using System.IO;

namespace EuromillionsML
{
    public static class Constants
    {
        public static readonly string _trainDataPath = Path.Combine("..\\..\\..\\Data\\drawns.csv");
        public static readonly string _testDataPath = Path.Combine("..\\..\\..\\Data\\drawns_test.csv");
        public static float dateToPredict => DateTime.Today.Ticks;
    }
}
