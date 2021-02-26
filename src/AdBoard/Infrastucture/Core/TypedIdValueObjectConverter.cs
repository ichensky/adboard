using Domain.Core;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Core
{
    public class TypedIdValuesObjectConverter : ValueConverter<TypedIdValueObject, Guid>
    {
        public TypedIdValuesObjectConverter(ConverterMappingHints? mappingHints = null)
            : base(id => id.Value, value => Create(value), mappingHints) { }

        private static TypedIdValueObject Create(Guid id)
        {
            if (Activator.CreateInstance(typeof(TypedIdValueObject), id) is not TypedIdValueObject value)
            {
                throw new Exception("value is null");
            }
            return value;
        }
    }
}
