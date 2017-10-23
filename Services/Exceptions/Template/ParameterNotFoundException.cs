namespace Services.Exceptions.Template
{
    public class ParameterNotFoundException : TemplateException
    {
        public ParameterNotFoundException(string paramName) : base($"The parameter {paramName} is not found !") { }
    }
}
