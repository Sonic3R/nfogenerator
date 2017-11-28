namespace Services.Parsers
{
    public sealed class DefaultParser : NfoParser
    {
        public DefaultParser(string filename) : base(filename)
        {
        }

        protected override string RegexInstallNotes => "";

        protected override string GetInstallNote()
        {
            return string.Empty;
        }
    }
}
