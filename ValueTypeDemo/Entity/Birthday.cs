//-----------------------------------------------------------------------
// <copyright file="Birthday.cs" company="Lifeprojects.de">
//     Class: Birthday
//     Copyright © Lifeprojects.de 2021
// </copyright>
//
// <author>Gerhard Ahrens - Lifeprojects.de</author>
// <email>gerhard.ahrens@lifeprojects.de</email>
// <date>25.11.2021</date>
//
// <summary>
// Klasse für Entity ValueType Birthday
// </summary>
//-----------------------------------------------------------------------

namespace EasyPrototyping.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ValueTypeDemo.Core;

    public class Birthday : ValueObjectBase, IFormattable
    {
        public Birthday(DateTime value)
        {
            if (value > new DateTime(1900, 1, 1) && value < new DateTime(2199, 12, 31))
            {
                this.Value = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException("value", "variable value must be between 1900/1/1 and 2199/12/31.");
            }
        }

        public Birthday(int year, int month, int day)
        {

            if (new DateTime(year,month,day) > new DateTime(1900, 1, 1) && new DateTime(year, month, day) < new DateTime(2199, 12, 31))
            {
                this.Value = new DateTime(year, month, day);
            }
            else
            {
                throw new ArgumentOutOfRangeException("value", "variable value must be between 1900/1/1 and 2199/12/31.");
            }
        }

        public DateTime Value { get; }

        public int Day
        {
            get { return this.Value.Day; }
        }

        public int Month
        {
            get { return this.Value.Month; }
        }

        public int Year
        {
            get { return this.Value.Year; }
        }

        public string ToString(string format)
        {
            return this.Value.ToString(format);
        }

        public DateTime ToDateTime()
        {
            return this.Value;
        }

        public int AgeInYear()
        {
            return this.Value.GetAge();
        }

        public int AgeInDays()
        {
            DateTime d1 = DateTime.Now;
            DateTime d2 = this.Value;

            TimeSpan t = d1 - d2;
            double days = t.TotalDays;
            return (int)days;
        }

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
            return this.Value.ToString("d");
        }
        #endregion Implementation of override methodes

        #region Implementation of IFormattable

        public string ToString(String format, IFormatProvider formatProvider)
        {
            return this.Value.ToString(format, formatProvider);
        }

        #endregion Implementation of IFormattable

        #region Implementation of overload operators
        public static bool operator ==(Birthday a, Birthday b)
        {
            return EqualOperator<DateTime>(a.ToDateTime(), b.ToDateTime());
        }

        public static bool operator !=(Birthday a, Birthday b)
        {
            return NotEqualOperator<DateTime>(a.ToDateTime(), b.ToDateTime());
        }

        public static bool operator > (Birthday a, Birthday b)
        {
            return GreaterThanOperator(a, b);
        }

        public static bool operator >=(Birthday a, Birthday b)
        {
            return GreaterThanOrEqualOperator<DateTime>(a.ToDateTime(), b.ToDateTime());
        }

        public static bool operator < (Birthday a, Birthday b)
        {
            return LessThanOperator<DateTime>(a.ToDateTime(), b.ToDateTime());
        }

        public static bool operator <=(Birthday a, Birthday b)
        {
            return LessThanOrEqualOperator<DateTime>(a.ToDateTime(), b.ToDateTime());
        }
        #endregion Implementation of overload operators

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return this.Value;
        }
    }
}
