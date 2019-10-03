using System.Configuration;
namespace GetXmlFiles
{
    class XmlConfig
    {
        public string InputDirectory { get; set; }
        public string OutputFilePath { get; set; }

        public XmlConfig()
        {
            InputDirectory = ConfigurationManager.AppSettings.Get("input_directory");
            OutputFilePath = ConfigurationManager.AppSettings.Get("output_file");
        }
    }
}
