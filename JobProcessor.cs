using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Threading;

namespace GetXmlFiles
{
    class JobProcessor
    {
        private static object StateInfo;
        private readonly StringBuilder _contentBuilder;
        private readonly Logger _logger;
        private readonly XmlConfig _config;
       // private readonly InitializeTimer _timer;

        private const string TAG_JOB_TITLE = "JobTitle";
        private const string TAG_JOB_EMPLOYER = "Employer";
        private const string TAG_JOB_EMPLOYERROLE = "EmployerRole";
        private const string TAG_JOB_PERIOD = "Period";

        private const int PAD_JOB_TITLE = 30;
        private const int PAD_JOB_EMPLOYER = 30;
        private const int PAD_JOB_EMPLOYERROLE = 30;
        private const int PAD_JOB_PERIOD = 100;

        private const string TAG_HEADER_FORMAT = "{0}{1}{2}{3}\n";

        public JobProcessor()
        {
            _contentBuilder = new StringBuilder();
            _config = new XmlConfig();
            _logger = new Logger(_config.OutputFilePath);

            _contentBuilder.AppendFormat(TAG_HEADER_FORMAT, TAG_JOB_TITLE.PadRight(PAD_JOB_TITLE),
                                                            TAG_JOB_EMPLOYER.PadRight(PAD_JOB_EMPLOYER),
                                                            TAG_JOB_EMPLOYERROLE.PadRight(PAD_JOB_EMPLOYERROLE),
                                                            TAG_JOB_PERIOD.PadRight(PAD_JOB_PERIOD));
            _contentBuilder.Append("--------------------------------------------------------------------");
            _contentBuilder.Append("--------------------------------------------------------------------\n");
        }

        public void Process(object StateInfo)
        {
            var files = Directory.GetFiles(_config.InputDirectory, "*.xml", SearchOption.AllDirectories);

            foreach (string file in files)
            {
                Console.WriteLine($"Processing File: {file}");
                if (File.Exists(file))
                    ProcessFile(file);
                else
                    Console.WriteLine("{0} is not a valid file or directory.", file);
            }

            _logger.WriteContent(_contentBuilder.ToString());
        }

        private void ProcessFile(string filePath)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);

            var jobTitle = xmlDocument.SelectSingleNode("//jobtitle");
            var employer = xmlDocument.SelectSingleNode("//employer");
            var employerRole = xmlDocument.SelectSingleNode("//employerrole");
            var period = xmlDocument.SelectSingleNode("//period");

            if (jobTitle != null)
                _contentBuilder.Append(jobTitle.InnerText.PadRight(PAD_JOB_TITLE));

            if (employer != null)
                _contentBuilder.Append(employer.InnerText.PadRight(PAD_JOB_EMPLOYER));

            if (employerRole != null)
                _contentBuilder.Append(employerRole.InnerText.PadRight(PAD_JOB_EMPLOYERROLE));

            if (period != null)
                _contentBuilder.Append(period.InnerText.PadRight(PAD_JOB_PERIOD));
            _contentBuilder.AppendLine();
        }
    }
}
