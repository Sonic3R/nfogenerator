using HtmlAgilityPack;
using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Linq;

namespace Services
{
    public sealed class InfektExecutor
    {
        private string _infektExePath;

        public InfektExecutor() : this(ConfigurationManager.AppSettings["infektPath"])
        {
        }

        public InfektExecutor(string infektExePath)
        {
            if (string.IsNullOrWhiteSpace(infektExePath))
            {
                throw new ArgumentNullException(nameof(infektExePath));
            }

            _infektExePath = infektExePath;
        }

        public string ExtractInstallNotes(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(nameof(filePath));
            }

            string htmlPath = Path.ChangeExtension(filePath, "html");

            using (Process process = new Process())
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.FileName = _infektExePath;
                startInfo.Arguments = $"{filePath} -m -O {htmlPath}";
                process.StartInfo = startInfo;
                process.Start();
            }

            if (File.Exists(htmlPath))
            {
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(File.ReadAllText(htmlPath));

                HtmlNodeCollection elems = doc.DocumentNode.SelectNodes("//*[contains(@class,'nfo_text')]");

                if (elems == null)
                {
                    return string.Empty;
                }

                StringBuilder sb = new StringBuilder();
                foreach (var elem in elems)
                {
                    sb.AppendLine(elem.InnerText);
                }

                return sb.ToString();
            }

            return string.Empty;
        }
    }
}
