namespace Services.Exceptions.Template
{
    public class MismatchNumberOfParametersException : TemplateException
    {
        public MismatchNumberOfParametersException() : base("Number of parameters is less than 0 or does not match with provided one") { }
    }
}
