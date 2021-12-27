//-----------------------------------------------------------------------
// <copyright file="Firstname.cs" company="Lifeprojects.de">
//     Class: Firstname
//     Copyright © Lifeprojects.de 2021
// </copyright>
//
// <author>Gerhard Ahrens - Lifeprojects.de</author>
// <email>gerhard.ahrens@lifeprojects.de</email>
// <date>25.11.2021</date>
//
// <summary>
// Klasse für Entity ValueType Firstname
// </summary>
//-----------------------------------------------------------------------

namespace EasyPrototyping.Entity
{
    using System.Collections.Generic;

    using ValueTypeLibrary.Core;

    public sealed class Picture : ValueObjectBase, IValueObject<byte[], Picture>
    {
        public Picture(byte[] value)
        {
        }

        public byte[] Value { get; }

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
            return string.Empty;
        }
        #endregion Implementation of override methodes

        #region Implementation of overload operators
        public static bool operator ==(Picture a, Picture b)
        {
            return EqualOperator(a.Value, b.Value);
        }

        public static bool operator !=(Picture a, Picture b)
        {
            return NotEqualOperator(a.Value, b.Value);
        }
        #endregion Implementation of overload operators

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return this.Value;
        }
    }
}
