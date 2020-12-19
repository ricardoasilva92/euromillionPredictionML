using System.IO;

namespace EuromillionsML
{
    public static class FileDirectories
    {
        public static readonly string _trainDataPath = Path.Combine("C:\\Projects\\EuromillionsML\\EuromillionsML", "Data", "drawns.csv");
        public static readonly string _testDataPath = Path.Combine("C:\\Projects\\EuromillionsML\\EuromillionsML", "Data", "drawns_test.csv");
        public static readonly string _modelPath = Path.Combine("C:\\Projects\\EuromillionsML\\EuromillionsML", "Data", "Model.zip");
    }
}
