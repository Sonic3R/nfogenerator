using System;

namespace Services.Exceptions.Template
{
    public abstract class TemplateException : Exception
    {
        public TemplateException(string message) : base(message) { }
    }
}
