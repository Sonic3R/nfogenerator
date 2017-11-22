using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Services.Parsers
{
    public class CodexParser : NfoParser
    {
        public CodexParser(string filename) : base(filename)
        {
        }

        protected override string RegexInstallNotes => @"(?:\-)\s(?:(.*)(?:(.*))?)(?:([\r\n]+(.*)))";

        protected override string GetInstallNote()
        {
            return "- Extract\r\n- Burn or mount the.iso\r\n- Run setup.exe and install\r\n- Copy crack from CODEX dir to installdir\r\n-Play\r\n\r\nGeneral Notes:\r\n-Block the game's exe in your firewall to prevent the game from trying to go online ..\r\n-If you install games to your systemdrive, it may be necessary to run this game with admin privileges instead";

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
            //        foreach(string split in splits)
            //        {
            //            if (split.StartsWith("-"))
            //            {
            //                sb.Append(split);
            //            } else
            //            {
            //                if (split.IndexOf("general notes", StringComparison.OrdinalIgnoreCase) > -1)
            //                {
            //                    sb.Append("\r\n\r\n\r\n");
            //                    sb.Append("General notes: \r\n");
            //                }
            //                else
            //                {
            //                    sb.Append($" {split.Trim(new char[] { '\r', '\n' })}\r\n");
            //                }
            //            }
            //        }
            //    }

            //    return sb.ToString();
            //}

            //return string.Empty;
        }
    }
}
