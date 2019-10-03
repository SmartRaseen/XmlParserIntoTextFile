using System.IO;

namespace GetXmlFiles
{
    class Logger
    {
        private readonly string _logFilePath;
        public Logger(string filePath)
        {
            _logFilePath = filePath;
            var directory = Path.GetDirectoryName(_logFilePath);
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
        }

        public void WriteContent(string fileContent)
        {
            File.AppendAllText(_logFilePath, fileContent);
        }
    }
}
