using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Services.Parsers
{
    public sealed class ReloadedParser : NfoParser
    {
        public ReloadedParser(string filename) : base(filename)
        {
        }

        protected override string RegexInstallNotes => @"(?:\d+)\.\s(?:(.*)(?:\n {3,}(.*))?)";

        protected override string GetInstallNote()
        {
            return "1. Unrar.\r\n2. Burn or mount the image.\r\n3. Install the game.\r\n4. Copy over the cracked content from the /Crack directory on the image to your game install directory.\r\n5. Play the game.\r\n6. Support the software developers. If you like this game, BUY IT!";
            //InfektExecutor exec = new InfektExecutor();
            //string data = GetNfoAsText();

            //if (string.IsNullOrWhiteSpace(data))
            //{
            //    return string.Empty;
            //}

            //data = data.RemoveNonAscii().Trim();

            //Regex regex = new Regex(RegexInstallNotes);
            //MatchCollection matches = regex.Matches(data);
            //if (matches.Count > 0)
            //{
            //    StringBuilder sb = new StringBuilder();

            //    foreach (Match match in matches)
            //    {
            //        var splits = match.Value.Split(new char[] { '\r', '\n' });
            //        foreach (string split in splits)
            //        {
            //            if (Regex.IsMatch(split, @"^\d+"))
            //            {
            //                sb.Append(split);
            //            }
            //            else
            //            {
            //                sb.Append($" {split}\r\n");
            //            }
            //        }
            //    }

            //    return sb.ToString();
            //}

            //return string.Empty;
        }
    }
}
