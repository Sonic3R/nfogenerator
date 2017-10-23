using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Services
{
    public static class StringHelper
    {
        private static IDictionary<string, string> _dict = new Dictionary<string, string>
        {
            { @"<strong>(.*?)<\/strong>", "[b]$1[/b]" },
            { @"<br\s?\/?>", "\r\n" }
        };

        /// <summary>
        /// Remove non ASCII
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveNonAscii(this string str)
        {
            return Regex.Replace(str, @"[^\u0000-\u007F]+", string.Empty);
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

            return string.Empty;
        }
    }
}
