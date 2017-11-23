namespace Services.Parsers
{
    public sealed class PlazaParser : NfoParser
    {
        public PlazaParser(string filename) : base(filename)
        {
        }

        protected override string RegexInstallNotes => "";

        protected override string GetInstallNote()
        {
            return "1. Extract release\r\n2.Mount ISO\r\n3.Install the game\r\n4.Play!\r\n\r\nGeneral Notes:\r\n-Block the game's exe in your firewall to prevent the game from trying to go online ..\r\n-If you install games to your systemdrive, it may be necessary to run this game with admin privileges instead";
        }
    }
}
