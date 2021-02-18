using Domain.Core.BusinessRules;
using System;
using System.Collections.Generic;

namespace Domain.Core
{
    public class TypedIdValueObject : SingleValueObject<Guid>
    {
        protected TypedIdValueObject()
        {
            // For EF
        }

        public TypedIdValueObject(Guid id) : base(id) { }

        protected override void CheckChangeRule(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new BusinessRuleValidationException($"Id should not be empty");
            }
        }
    }
}
