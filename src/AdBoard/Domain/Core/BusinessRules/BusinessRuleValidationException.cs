using System;

namespace Domain.Core.BusinessRules
{
    public class BusinessRuleValidationException : Exception
    {
        public BusinessRuleValidationException(string message) : base(message) { }
    }
}