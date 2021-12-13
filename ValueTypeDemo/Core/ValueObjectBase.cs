namespace ValueTypeDemo.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    [Serializable]
    public abstract class ValueObjectBase : ICloneable
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

        public object Clone()
        {
            /*
            var aa = MyCreateInstance(this.GetType());
            ParameterInfo[] parameters = this.GetType().GetConstructors()[0].GetParameters();
            object newObject = Activator.CreateInstance(this.GetType(), new object[] { parameters[0].ParameterType.GetEnumValues().GetValue(0) });

            //We get the array of fields for the new type instance.
            FieldInfo[] fields = newObject.GetType().GetFields();
            */
            return MemberwiseClone();
        }

        public static object MyCreateInstance(Type type)
        {
            var parametrizedCtor = type
                .GetConstructors()
                .FirstOrDefault(c => c.GetParameters().Length > 0);

            return parametrizedCtor != null
                ? parametrizedCtor.Invoke
                    (parametrizedCtor.GetParameters()
                        .Select(p =>
                            p.HasDefaultValue ? p.DefaultValue :
                            p.ParameterType.IsValueType && Nullable.GetUnderlyingType(p.ParameterType) == null
                                ? Activator.CreateInstance(p.ParameterType)
                                : null
                        ).ToArray()
                    )
                : Activator.CreateInstance(type);
        }
    }
}
