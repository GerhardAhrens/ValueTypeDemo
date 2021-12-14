namespace ValueTypeDemo.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    [Serializable]
    public abstract class ValueObjectBase : ICloneable
    {
        public ValueObjectBase()
        {
            this.ObjectId = Guid.NewGuid();
        }
        public Guid ObjectId { get; private set; }

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

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public T CloneTo<T>()
        {
            return (T)this.MemberwiseClone();
        }

        public IEnumerable<string> GetValues()
        {
            return this.GetEqualityComponents().Select(x => x.ToString());
        }

        public IEnumerable<PropertyInfo> GetProperties()
        {
            return this.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public).ToList();
        }
    }
}
