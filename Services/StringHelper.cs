using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Services
{
    public static class StringHelper
    {
        private static IDictionary<string, string> _dict = new Dictionary<string, string>
        {
            { @"<strong>(.*?)<\/strong>", "[b]$1[/b]" },
            { @"<br\s?\/?>", "\r\n" },
            { @"<i>(.*?)<\/i>", "[i]$1[/i]" },
            { @"</?ul\s?(.*?)>", "" },
            { @"<li>(.*?)(\r\n)?</li>", "[*] $1\r\n" },
            { @"</li><li>(.*?)", "[*] $1\r\n" },
            { "<a (href=\"(.*?)\")?(.*)?>(.*?)</a>", "[url=$2]$4[/url]" }
        };

        /// <summary>
        /// Remove non ASCII
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveNonAscii(this string str)
        {
            string result = Regex.Replace(str, @"[^\u0000-\u007F]+", string.Empty);
            result = Regex.Replace(result, "(\r\n){3,}", string.Empty, RegexOptions.Multiline);

            return result;
        }

        /// <summary>
        /// To BBCode
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToBbcode(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return str;
            }

            string result = str;

            foreach(var kvp in _dict)
            {
                result = Regex.Replace(result, kvp.Key, kvp.Value, RegexOptions.Multiline);
            }

            return result;
        }

        public static string WithoutQueryString(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return str;
            }

            return new Uri(str).GetLeftPart(UriPartial.Path);
        }
    }
}
