namespace Services.Parsers
{
    public sealed class SkidrowParser : NfoParser
    {
        public SkidrowParser(string filename) : base(filename)
        {
        }

        protected override string RegexInstallNotes => @"(\d+)\.\s(.*)([\r\n]+\s+(.*))?";
    }
}
