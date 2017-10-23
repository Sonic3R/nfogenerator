namespace Services.Exceptions.Template
{
    public class InvalidParameterInTemplateException : TemplateException
    {
        public InvalidParameterInTemplateException() : base("Invalid parameters in template. Those must start with -- followed by string without space, use underscores, instead !") { }
    }
}
