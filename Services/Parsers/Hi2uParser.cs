namespace Services.Parsers
{
    public sealed class Hi2uParser : NfoParser
    {
        public Hi2uParser(string filename) : base(filename)
        {
        }

        protected override string RegexInstallNotes => "";

        protected override string GetInstallNote()
        {
            return "[1] Unpack\r\n[2] Mount / burn image\r\n[3] Install\r\n[4] Play game\r\n[5] If U like it, buy it!";
        }
    }
}
