using Domain.Core;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace Infrastucture.Core
{
    public class SingleValueObjectConverter<S, T> : ValueConverter<S, T> where S: SingleValueObject<T>
    {
        public SingleValueObjectConverter(ConverterMappingHints? mappingHints = null)
               : base(id => id.Value, value => Create(value), mappingHints) { }

        private static S Create(T id)
        {
            if (Activator.CreateInstance(typeof(S), id) is not S value)
            {
                throw new Exception("value is null");
            }
            return value;
        }

    }
}
