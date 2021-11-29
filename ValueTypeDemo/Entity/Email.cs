//-----------------------------------------------------------------------
// <copyright file="Email.cs" company="Lifeprojects.de">
//     Class: Email
//     Copyright © Lifeprojects.de 2021
// </copyright>
//
// <author>Gerhard Ahrens - Lifeprojects.de</author>
// <email>gerhard.ahrens@lifeprojects.de</email>
// <date>25.11.2021</date>
//
// <summary>
// Klasse für Domain ValueType Email
// </summary>
//-----------------------------------------------------------------------

namespace EasyPrototyping.Entity
{
    using System;
    using System.Diagnostics;
    using System.Text.RegularExpressions;

    [DebuggerDisplay("Value={Value}; IsConfirmed={IsConfirmed}")]
    public class Email : IEquatable<Email>, IComparable<Email>
    {
        public Email(string value = "")
        {
            if (this.CheckValue(value) == true)
            {
                this.Id = Guid.NewGuid();
                this.Value = value;
                this.IsConfirmed = true;
            }
            else
            {
                this.Id = Guid.NewGuid();
                this.Value = value;
                this.IsConfirmed = false;
            }
        }

        public Guid Id { get; private set; }

        public string Value { get; }

        public bool IsConfirmed { get; private set; }


        public bool Equals(Email other)
        {
            return this.Value == other?.Value && this.IsConfirmed == other?.IsConfirmed;
        }

        public override bool Equals(object @this)
        {
            if (ReferenceEquals(null, @this))
            {
                return false;
            }

            return @this is Email && Equals((Email)@this);
        }

        public int CompareTo(Email other) => Value.CompareTo(other.Value);

        public override int GetHashCode()
        {
            unchecked
            {
                return ((this.Value != null ? this.Value.GetHashCode() : 0) * 397) ^ IsConfirmed.GetHashCode();
            }
        }


        public override string ToString()
        {
            return this.Value;
        }

        public static bool operator ==(Email a, Email b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Email a, Email b)
        {
            return !(a == b);
        }

        private bool CheckValue(string value)
        {
            bool result = true;

            if (string.IsNullOrEmpty(value) == true)
            {
                result = false;
            }
            else
            {
                Regex _pattern = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.Compiled);
                result = _pattern.IsMatch(value);
            }

            return result;
        }
    }
}
