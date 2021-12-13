namespace ValueTypeDemo.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    [Serializable]
    public abstract class ValueObjectBase
    {
        protected static bool EqualOperator(ValueObjectBase? left, ValueObjectBase? right)
        {
            if (ReferenceEquals(left, objB: null) ^ ReferenceEquals(right, objB: null))
            {
                return false;
            }

            return ReferenceEquals(left, objB: null) || left.Equals(right);
        }

        protected static bool NotEqualOperator(ValueObjectBase left, ValueObjectBase right)
        {
            return !(EqualOperator(left, right));
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (ValueObjectBase)obj;

            return this.GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        protected abstract IEnumerable<object?> GetEqualityComponents();

        public override int GetHashCode()
        {
            return this.GetEqualityComponents()
                  .Select(x => x != null ? x.GetHashCode(): 0)
                  .Aggregate((x, y) => x ^ y);
        }

        public IEnumerable<PropertyInfo> GetProperties()
        {
            var aa = this.GetEqualityComponents().Select(x => x.GetType().GetProperty(x.ToString()));
            return GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).ToList();
        }
    }
}
