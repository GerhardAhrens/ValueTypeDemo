//-----------------------------------------------------------------------
// <copyright file="Probability.cs" company="Lifeprojects.de">
//     Class: Probability
//     Copyright © Lifeprojects.de 2021
// </copyright>
//
// <author>Gerhard Ahrens - Lifeprojects.de</author>
// <email>gerhard.ahrens@lifeprojects.de</email>
// <date>25.11.2021</date>
//
// <summary>
// Klasse für Entity ValueType Probability (als Struct)
// </summary>
//-----------------------------------------------------------------------

namespace EasyPrototyping.Entity
{
    using System;
    using System.Collections.Generic;

    using ValueTypeDemo.Core;

    public sealed class Probability : ValueObjectBase
    {
        public Probability(decimal value)
        {
            if (value < 0 || value > 1)
            {
                throw new ArgumentOutOfRangeException("value","The range must 0 between 1");
            }

            this.Value = value;
        }

        public decimal Value { get;}

        public double ToDouble()
        {
            return Convert.ToDouble(this.Value);
        }

        public decimal WeightOutcome(double outcome)
        {
            return this.Value * Convert.ToDecimal(outcome);
        }

        #region Implementation of overload operators
        public static bool operator ==(Probability a, Probability b)
        {
            return EqualOperator(a, b);
        }

        public static bool operator !=(Probability a, Probability b)
        {
            return NotEqualOperator(a, b);
        }

        public static bool operator > (Probability a, Probability b)
        {
            return GreaterThanOperator(a, b);
        }

        public static bool operator >= (Probability a, Probability b)
        {
            return GreaterThanOrEqualOperator(a, b);
        }

        public static bool operator < (Probability a, Probability b)
        {
            return LessThanOperator(a, b);
        }

        public static bool operator <=(Probability a, Probability b)
        {
            return LessThanOrEqualOperator(a, b);
        }

        public static Probability operator + (Probability a, Probability b)
        {
            return new Probability(a.Value + b.Value);
        }

        public static Probability operator - (Probability a, Probability b)
        {
            return new Probability(a.Value - b.Value);
        }
        #endregion Implementation of overload operators

        #region Implementation of override methodes
        public override bool Equals(object @this)
        {
            return base.Equals(@this);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }

        public string ToString(string format)
        {
            return this.Value.ToString(format);
        }
        #endregion Implementation of override methodes

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return this.Value;
        }
    }
}