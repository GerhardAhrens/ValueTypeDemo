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
// Klasse für Entity ValueType Email
// </summary>
//-----------------------------------------------------------------------

namespace EasyPrototyping.Entity
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text.RegularExpressions;

    using ValueTypeLibrary.Core;

    [DebuggerDisplay("Value={Value}; IsConfirmed={IsConfirmed}")]
    public sealed class Email : ValueObjectBase, IValueObject<string, Email>
    {
        public Email(string value = "")
        {
            if (this.CheckValue(value) == true)
            {
                this.Value = value;
                this.IsConfirmed = true;
            }
            else
            {
                this.Value = value;
                this.IsConfirmed = false;
            }
        }

        /// <summary>
        /// Gibt die EMail Adresse zurück
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Gibt an, ob die EMail-Adresse formal valide ist zurück (True=Ok. False=Fehler)
        /// </summary>
        public bool IsConfirmed { get; }

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
        public static bool operator == (Email a, Email b)
        {
            return EqualOperator(a.Value, b.Value);
        }

        public static bool operator != (Email a, Email b)
        {
            return NotEqualOperator(a.Value, b.Value);
        }
        #endregion Implementation of overload operators

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

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return this.Value;
            yield return this.IsConfirmed;
        }
    }
}
