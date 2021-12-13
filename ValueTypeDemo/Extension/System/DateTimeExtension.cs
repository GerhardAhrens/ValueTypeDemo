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
    }
}
