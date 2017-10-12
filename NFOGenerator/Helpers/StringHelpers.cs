using System.Text.RegularExpressions;

namespace NFOGenerator.Helpers
{
    public static class StringHelpers
    {
        /// <summary>
        /// Remove non ASCII
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveNonAscii(this string str)
        {
            return Regex.Replace(str, @"[^\u0000-\u007F]+", string.Empty);
        }
    }
}