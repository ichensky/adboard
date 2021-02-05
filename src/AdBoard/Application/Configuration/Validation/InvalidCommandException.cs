using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Configuration.Validation
{
    public class InvalidCommandException : Exception
    {
 
        public InvalidCommandException(string message, string? details = null) : base(message)
        {
            this.Details = details;
        }

        public string? Details { get; }
    }
}
