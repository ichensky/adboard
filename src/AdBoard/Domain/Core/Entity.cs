using Domain.Core.BusinessRules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core
{
    public abstract class Entity :  IEntity
    {
        public Guid Id { get; }
    }
}
