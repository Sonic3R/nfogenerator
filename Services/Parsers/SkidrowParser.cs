namespace Services.Parsers
{
    public sealed class SkidrowParser : NfoParser
    {
        public SkidrowParser(string filename) : base(filename)
        {
        }

        protected override string RegexInstallNotes => @"(\d+)\.\s(.*)([\r\n]+\s+(.*))?";

        protected override string GetInstallNote()
        {
            return "1. Unpack the release\r\n2. Mount or burn image\r\n3. Install\r\n4. Copy the cracked content from the SKIDROW folder and into the main install folder and overwrite\r\n5. Block the game in your firewall and mark our cracked content as secure/trusted in your antivirus program\r\n6. Play the game\r\n7. Support the companies, which software you actually enjoy!";
        }
    }
}
