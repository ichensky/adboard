using System;

namespace Domain.Core
{
    public abstract class SingleValueObject<T> : ValueObject    {
        private T value;

        protected SingleValueObject()
        {
            // For EF
        }

        public SingleValueObject(T value)
        {
            CheckChangeRule(value);
            this.value = value;
        }

        public T Value { get => value; }

        public void Change(T newValue)
        {
            CheckChangeRule(newValue);
            value = newValue;
        }

        protected abstract void CheckChangeRule(T value);
    }
}