using System;

namespace Application.Configuration.Validation
{
    public class InvalidCommandException : Exception
    {
        public InvalidCommandException(string message, string? details) : base(message)
        {
            this.Details = details;
        }

        public string? Details { get; }
    }
}
