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
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text.RegularExpressions;

    using ValueTypeDemo.Core;

    [DebuggerDisplay("Value={Value}; IsConfirmed={IsConfirmed}")]
    public class Firstname : ValueObjectBase, IValueObject<string>
    {
        public Firstname(string value = "", bool firstCharUpper = true)
        {
            if (firstCharUpper == true)
            {
                this.PhoneticCode = value.SoundEx();
                this.Value = string.Concat(value[0].ToString().ToUpper(), value.AsSpan(1));
            }
            else
            {
                this.Value = value;
            }
        }

        public string Value { get; }

        public string PhoneticCode { get; }

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
            return this.Value;
        }
        #endregion Implementation of override methodes

        #region Implementation of overload operators
        public static bool operator ==(Firstname a, Firstname b)
        {
            return EqualOperator(a.Value, b.Value);
        }

        public static bool operator !=(Firstname a, Firstname b)
        {
            return NotEqualOperator(a.Value, b.Value);
        }
        #endregion Implementation of overload operators

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return this.Value;
            yield return this.PhoneticCode;
        }
    }
}
