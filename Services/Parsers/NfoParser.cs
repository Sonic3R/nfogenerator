using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Services
{
    public abstract class NfoParser
    {
        private string _filename;

        public NfoParser(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentNullException(nameof(filename));
            }

            _filename = filename;
        }

        protected abstract string RegexInstallNotes { get; }

        public string GetInstallNote()
        {
            string data = File.ReadAllText(_filename);
            if (string.IsNullOrWhiteSpace(data))
            {
                return string.Empty;
            }

            Regex regex = new Regex(RegexInstallNotes);
            MatchCollection matches = regex.Matches(data);
            if (matches.Count>0)
            {
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < matches.Count - 1; i++)
                {
                    sb.AppendLine($"{i + 1}. {matches[i].Groups[2].Value}");
                }

                return sb.ToString();
            }

            return string.Empty;
        }
    }
}
