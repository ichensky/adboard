using Domain.Core;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Core
{
    public class TypedIdValueObjectConverter<TTypedIdValue> : ValueConverter<TTypedIdValue, Guid>
        where TTypedIdValue : TypedIdValueObject
    {
        public TypedIdValueObjectConverter(ConverterMappingHints mappingHints = null)
            : base(id => id.Value, value => Create(value), mappingHints)
        {
        }

        private static TTypedIdValue Create(Guid id)
        {
            var value=  Activator.CreateInstance(typeof(TTypedIdValue), id) as TTypedIdValue;
            if (value == null)
            {
                throw new Exception("value is null");
            }
            return value;
        }
    }
}
