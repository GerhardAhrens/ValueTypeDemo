//-----------------------------------------------------------------------
// <copyright file="NumericExtension.cs" company="Lifeprojects.de">
//     Class: NumericExtension
//     Copyright © Lifeprojects.de 2021
// </copyright>
//
// <author>Gerhard Ahrens - Lifeprojects.de</author>
// <email>gerhard.ahrens@lifeprojects.de</email>
// <date>27.12.2021</date>
//
// <summary>
// Klasse für Generic Numeric Extension
// </summary>
//-----------------------------------------------------------------------

namespace System
{
    using System.Collections.Generic;

    public static class NumericExtension
    {
        private readonly static HashSet<Type> NumericTypes = new HashSet<Type>()
    {
        typeof(byte), typeof(sbyte), typeof(ushort), typeof(uint), typeof(ulong), typeof(short), typeof(int), typeof(Int16), typeof(Int32), typeof(Int64), typeof(long), typeof(decimal), typeof(double), typeof(float)
    };

        public static bool IsNumeric(this object o) => NumericTypes.Contains(o.GetType());

        /// <summary>
        /// Die Methode 'IsBetween' prüft, ob ein Wert zwischen einem größten und kleinsten Wert liegt.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">Zu prüfender Wert</param>
        /// <param name="lowest">Kleinster Wert</param>
        /// <param name="highest">Höchster wert</param>
        /// <returns></returns>
        public static bool IsBetween<T>(this T @this, T minValue, T maxValue) where T : IComparable
        {
            return (Comparer<T>.Default.Compare(minValue, @this) <= 0 && Comparer<T>.Default.Compare(maxValue, @this) >= 0);
        }

        public static bool IsNotBetween<T>(this T @this, T minValue, T maxValue) where T : IComparable
        {
            return @this.IsBetween(minValue,maxValue) == false;
        }
    }
}
