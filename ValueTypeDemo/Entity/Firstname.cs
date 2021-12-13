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
    using System.Diagnostics;
    using System.Text.RegularExpressions;

    [DebuggerDisplay("Value={Value}; IsConfirmed={IsConfirmed}")]
    public class Firstname : IEquatable<Firstname>, IComparable<Firstname>
    {
        public Firstname(string value = "", bool firstCharUpper = true)
        {
            this.Id = Guid.NewGuid();

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

        public Guid Id { get; private set; }

        public string Value { get; }

        public string PhoneticCode { get; }

        public bool Equals(Firstname other)
        {
            return this.Value == other?.Value;
        }

        public override bool Equals(object @this)
        {
            if (ReferenceEquals(null, @this))
            {
                return false;
            }

            return @this is Firstname && Equals((Firstname)@this);
        }

        public int CompareTo(Firstname other) => Value.CompareTo(other.Value);

        public override int GetHashCode()
        {
            unchecked
            {
                return ((this.Value != null ? this.Value.GetHashCode() : 0) * 397);
            }
        }


        public override string ToString()
        {
            return this.Value;
        }

        public static bool operator ==(Firstname a, Firstname b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Firstname a, Firstname b)
        {
            return !(a == b);
        }
    }
}
