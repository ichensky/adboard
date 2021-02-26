using System;

namespace Domain.Core
{
    public abstract class SingleValueObject<T> : ValueObject, IEquatable<SingleValueObject<T>>
    {
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

        public bool Equals(SingleValueObject<T>? other)
        {
            if (other is null)
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return value!.Equals(other.value);
        }
        public override bool Equals(object? obj) => this.Equals(obj);

        public override int GetHashCode() => this.value == null ? 0 : this.value.GetHashCode();

        public static bool operator ==(SingleValueObject<T> o1, SingleValueObject<T> o2) => o1.Equals(o2);

        public static bool operator !=(SingleValueObject<T> o1, SingleValueObject<T> o2) => !o1.Equals(o2);
    }
}