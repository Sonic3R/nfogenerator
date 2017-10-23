using System.IO;
using System.Reflection;

namespace Services
{
    public static class TemplateManager
    {
        private static string TEMPLATE_URL = Path.Combine(Path.GetDirectoryName(Assembly.GetCallingAssembly().Location), "templates/game_nfo.txt");

        public static string GetTemplate()
        {
            return File.ReadAllText(TEMPLATE_URL);
        }
    }
}
