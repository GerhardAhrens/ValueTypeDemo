﻿//-----------------------------------------------------------------------
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
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text.RegularExpressions;

    using ValueTypeDemo.Core;

    [DebuggerDisplay("Value={Value}; IsConfirmed={IsConfirmed}")]
    public class Email : ValueObjectBase
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

        public string Value { get; }

        public bool IsConfirmed { get; private set; }

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
        public static bool operator ==(Email a, Email b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Email a, Email b)
        {
            return !(a == b);
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
