using Services.Exceptions.Template;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Services
{
    public static class TemplateManager
    {
        private static string GAME_TEMPLATE_URL = Path.Combine(Path.GetDirectoryName(Assembly.GetCallingAssembly().Location), "templates/game_nfo.txt");
        private static string MUSIC_TEMPLATE_URL = Path.Combine(Path.GetDirectoryName(Assembly.GetCallingAssembly().Location), "templates/music_nfo.txt");

        public static string RenderTemplate(IDictionary<string, string> nfoParams, ETemplateType templateType)
        {
            string templateData = templateType == ETemplateType.GAME ? ReadGameTemplate() : ReadMusicTemplate();
            Validate(templateData, nfoParams);

            string result = templateData;

            foreach(var kvp in nfoParams)
            {
                result = result.Replace($"-- {kvp.Key.ToLower()}", kvp.Value);
            }

            return result;
        }

        private static string ReadGameTemplate()
        {
            return File.ReadAllText(GAME_TEMPLATE_URL);
        }

        private static string ReadMusicTemplate()
        {
            return File.ReadAllText(MUSIC_TEMPLATE_URL);
        }

        private static void Validate(string text, IDictionary<string, string> providedParams)
        {
            string pattern = @"--\s?(\w+_?)";
            Regex regex = new Regex(pattern, RegexOptions.Multiline | RegexOptions.IgnorePatternWhitespace);

            MatchCollection matches = regex.Matches(text);
            if (matches.Count == 0)
            {
                throw new InvalidParameterInTemplateException();
            }
            
            List<string> data = new List<string>();
            for(int i=0; i < matches.Count; i++)
            {
                data.Add(matches[i].Groups[1].Value);
            }

            if(data.Count != providedParams.Count)
            {
                throw new MismatchNumberOfParametersException();
            }

            foreach(string d in data)
            {
                if (!providedParams.ContainsKey(d.Trim()))
                {
                    throw new ParameterNotFoundException(d);
                }
            }
        }
    }
}
