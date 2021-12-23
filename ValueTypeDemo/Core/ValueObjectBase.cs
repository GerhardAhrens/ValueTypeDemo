//-----------------------------------------------------------------------
// <copyright file="ValueObjectBase.cs" company="Lifeprojects.de">
//     Class: ValueObjectBase
//     Copyright © Lifeprojects.de 2021
// </copyright>
//
// <author>Gerhard Ahrens - Lifeprojects.de</author>
// <email>gerhard.ahrens@lifeprojects.de</email>
// <date>22.12.2021</date>
//
// <summary>
// Klasse für Abstract ValueObjectBase Class
// </summary>
//-----------------------------------------------------------------------

namespace ValueTypeDemo.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
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

        protected static bool GreaterThanOperator<T>(T a, T b)
        {
            ParameterExpression paramA = Expression.Parameter(typeof(T), nameof(a));
            ParameterExpression paramB = Expression.Parameter(typeof(T), nameof(b));

            BinaryExpression body = Expression.GreaterThan(paramA, paramB);
            var invokeGreaterThanOperator = Expression.Lambda<Func<T, T, bool>>(body, paramA, paramB).Compile();

            return invokeGreaterThanOperator(a, b);
        }

        protected static bool GreaterThanOrEqualOperator<T>(T a, T b)
        {
            ParameterExpression paramA = Expression.Parameter(typeof(T), nameof(a));
            ParameterExpression paramB = Expression.Parameter(typeof(T), nameof(b));

            BinaryExpression body = Expression.GreaterThanOrEqual(paramA, paramB);
            var invokeGreaterThanOrEqualOperator = Expression.Lambda<Func<T, T, bool>>(body, paramA, paramB).Compile();

            return invokeGreaterThanOrEqualOperator(a, b);
        }

        protected static bool LessThanOperator<T>(T a, T b)
        {
            ParameterExpression paramA = Expression.Parameter(typeof(T), nameof(a));
            ParameterExpression paramB = Expression.Parameter(typeof(T), nameof(b));

            BinaryExpression body = Expression.LessThan(paramA, paramB);
            var invokeLessThanOperator = Expression.Lambda<Func<T, T, bool>>(body, paramA, paramB).Compile();

            return invokeLessThanOperator(a, b);
        }

        protected static bool LessThanOrEqualOperator<T>(T a, T b)
        {
            ParameterExpression paramA = Expression.Parameter(typeof(T), nameof(a));
            ParameterExpression paramB = Expression.Parameter(typeof(T), nameof(b));

            BinaryExpression body = Expression.LessThanOrEqual(paramA, paramB);
            var invokeLessThanOrEqualOperator = Expression.Lambda<Func<T, T, bool>>(body, paramA, paramB).Compile();

            return invokeLessThanOrEqualOperator(a, b);
        }

        protected static bool EqualOperator<T>(T a, T b)
        {
            ParameterExpression paramA = Expression.Parameter(typeof(T), nameof(a));
            ParameterExpression paramB = Expression.Parameter(typeof(T), nameof(b));

            BinaryExpression body = Expression.Equal(paramA, paramB);
            var invokeEqualityOperator = Expression.Lambda<Func<T, T, bool>>(body, paramA, paramB).Compile();

            return invokeEqualityOperator(a, b);
        }

        protected static bool NotEqualOperator<T>(T a, T b)
        {
            ParameterExpression paramA = Expression.Parameter(typeof(T), nameof(a));
            ParameterExpression paramB = Expression.Parameter(typeof(T), nameof(b));

            BinaryExpression body = Expression.NotEqual(paramA, paramB);
            var invokeInequalityOperator = Expression.Lambda<Func<T, T, bool>>(body, paramA, paramB).Compile();

            return invokeInequalityOperator(a, b);
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
