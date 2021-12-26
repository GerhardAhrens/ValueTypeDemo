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

    public class Birthday : ValueObjectBase, IValueObject<DateTime, Birthday>, IFormattable
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

        /// <summary>
        /// Gibt das vollständige Datum als DateTime zurück
        /// </summary>
        public DateTime Value { get; }

        /// <summary>
        /// Gibt den Tag zurück
        /// </summary>
        public int Day
        {
            get { return this.Value.Day; }
        }

        /// <summary>
        /// Gibt den Monat zurück
        /// </summary>
        public int Month
        {
            get { return this.Value.Month; }
        }

        /// <summary>
        /// Gibt das Jahr zurück
        /// </summary>
        public int Year
        {
            get { return this.Value.Year; }
        }

        /// <summary>
        /// Gibt das Datum als String zurück, unter berücksichtigung der Format-Angabe
        /// </summary>
        /// <param name="format">Format-Angabe</param>
        /// <returns></returns>
        public string ToString(string format)
        {
            return this.Value.ToString(format);
        }

        /// <summary>
        /// Gibt das vollständige Datum als DateTime zurück
        /// </summary>
        /// <returns></returns>
        public DateTime ToDateTime()
        {
            return this.Value;
        }

        /// <summary>
        /// Gibt das Alter in Jahren zurück
        /// </summary>
        /// <returns></returns>
        public int AgeInYear()
        {
            return this.Value.GetAge();
        }

        /// <summary>
        /// Gibt das Alter in Tagen zurück
        /// </summary>
        /// <returns></returns>
        public int AgeInDays()
        {
            DateTime d1 = DateTime.Now;
            DateTime d2 = this.Value;

            TimeSpan t = d1 - d2;
            double days = t.TotalDays;
            return (int)days;
        }

        /// <summary>
        /// Prüft, ob das angegebene Datum in einerm Bereich zwischen 'dateIn' und 'dateOut' liegt.
        /// </summary>
        /// <param name="dateIn">Vergleichsdatum A</param>
        /// <param name="dateOut">Vergleichsdatum B</param>
        /// <returns>True wenn das Datum innherhalb des Vergelchsdatum A und B liegt, sonst False</returns>
        public bool Between(DateTime dateIn, DateTime dateOut)
        {
            return this.Value.Between(dateIn, dateOut);
        }

        /// <summary>
        /// Prüft, ob das angegebene Datum in einerm Bereich zwischen 'dateIn' und 'dateOut' liegt.
        /// </summary>
        /// <param name="dateIn">Vergleichsdatum A</param>
        /// <param name="dateOut">Vergleichsdatum B</param>
        /// <returns>True wenn das Datum innherhalb des Vergelchsdatum A und B liegt, sonst False</returns>
        public bool NotBetween(DateTime dateIn, DateTime dateOut)
        {
            return this.NotBetween(dateIn, dateOut);
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
            return EqualOperator<DateTime>(a.Value, b.Value);
        }

        public static bool operator !=(Birthday a, Birthday b)
        {
            return NotEqualOperator<DateTime>(a.Value, b.Value);
        }

        public static bool operator > (Birthday a, Birthday b)
        {
            return GreaterThanOperator(a.Value, b.Value);
        }

        public static bool operator >=(Birthday a, Birthday b)
        {
            return GreaterThanOrEqualOperator<DateTime>(a.Value, b.Value);
        }

        public static bool operator < (Birthday a, Birthday b)
        {
            return LessThanOperator<DateTime>(a.Value, b.Value);
        }

        public static bool operator <=(Birthday a, Birthday b)
        {
            return LessThanOrEqualOperator<DateTime>(a.Value, b.Value);
        }
        #endregion Implementation of overload operators

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return this.Value;
        }
    }
}
