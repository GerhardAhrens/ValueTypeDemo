//-----------------------------------------------------------------------
// <copyright file="StringExtension.cs" company="Lifeprojects.de">
//     Class: StringExtension
//     Copyright © Lifeprojects.de 2021
// </copyright>
//
// <author>Gerhard Ahrens - Lifeprojects.de</author>
// <email>gerhard.ahrens@lifeprojects.de</email>
// <date>29.11.2021</date>
//
// <summary>
// Klasse für DateTime Extension
// </summary>
//-----------------------------------------------------------------------

namespace System
{
    internal static class DateTimeExtension
    {
        public static int GetAge(this DateTime @this)
        {
            return GetAge(@this, DateTime.Now);
        }

        public static int GetAge(this DateTime? @this)
        {
            return GetAge(@this, DateTime.Now);
        }

        public static int GetAge(this DateTime @this, DateTime today)
        {
            bool hadBirthday = @this.Month < today.Month || (@this.Month == today.Month && @this.Day <= today.Day);

            return today.Year - @this.Year - (hadBirthday ? 0 : 1);
        }

        public static int GetAge(this DateTime? @this, DateTime today)
        {
            bool hadBirthday = ((DateTime)@this).Month < today.Month || (((DateTime)@this).Month == today.Month && ((DateTime)@this).Day <= today.Day);

            return today.Year - ((DateTime)@this).Year - (hadBirthday ? 0 : 1);
        }

        public static bool Between(this DateTime @this, DateTime minValue, DateTime maxValue)
        {
            bool result = false;
            if ((@this.Ticks > minValue.Ticks && @this.Ticks < maxValue.Ticks))
            {
                result = true;
            }

            return result;
        }

        public static bool NotBetween(this DateTime @this, DateTime minValue, DateTime maxValue)
        {
            return @this.Between(minValue, maxValue) == false;
        }

        /// <summary>
        /// Die Methode prüft, ob das Datum '@this' in der übergeben Liste von Type 'DateTime' enthalten ist
        /// </summary>
        /// <param name="this">The object to be compared.</param>
        /// <param name="values">The value list to compare with the object.</param>
        /// <returns>true if the values list contains the object, else false.</returns>
        /// ###
        /// <typeparam name="T">Generic type parameter.</typeparam>
        public static bool In(this DateTime @this, params DateTime[] values)
        {
            return Array.IndexOf(values, @this) != -1;
        }

        /// <summary>
        /// Die Methode prüft, ob das Datum '@this' in der übergeben Liste von Type 'DateTime' nicht enthalten ist
        /// </summary>
        /// <param name="this">The object to be compared.</param>
        /// <param name="values">The value list to compare with the object.</param>
        /// <returns>true if the values list doesn't contains the object, else false.</returns>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        public static bool NotIn(this DateTime @this, params DateTime[] values)
        {
            return Array.IndexOf(values, @this) == -1;
        }
    }
}
