//-----------------------------------------------------------------------
// <copyright file="Address.cs" company="Lifeprojects.de">
//     Class: Address
//     Copyright © Lifeprojects.de 2021
// </copyright>
//
// <author>Gerhard Ahrens - Lifeprojects.de</author>
// <email>gerhard.ahrens@lifeprojects.de</email>
// <date>13.12.2021</date>
//
// <summary>
// Klasse für Entity ValueType Address
// </summary>
//-----------------------------------------------------------------------

namespace EasyPrototyping.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ValueTypeDemo.Core;

    public class Address : ValueObjectBase
    {
        public Address(string country, string zip,string city, string street)
        {
            if (string.IsNullOrEmpty(country))
            {
                throw new ArgumentNullException(nameof(country));
            }

            if (string.IsNullOrEmpty(zip))
            {
                throw new ArgumentNullException(nameof(zip));
            }

            if (string.IsNullOrEmpty(city))
            {
                throw new ArgumentNullException(nameof(city));
            }

            if (string.IsNullOrEmpty(street))
            {
                throw new ArgumentNullException(nameof(street));
            }

            this.Country = country;
            this.Zip = zip;
            this.City = city;
            this.Street = street;
        }

        public string Country { get; private set; }

        public string Zip { get; private set; }

        public string City { get; private set; }

        public string Street { get; private set; }

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
            return $"{this.Country},{this.Zip},{this.City};{this.Street}";
        }
        #endregion Implementation of override methodes

        #region Implementation of overload operators
        public static bool operator ==(Address a, Address b)
        {
            return EqualOperator(a,b);
        }

        public static bool operator !=(Address a, Address b)
        {
            return NotEqualOperator(a,b);
        }
        #endregion Implementation of overload operators

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return this.Country;
            yield return this.Zip;
            yield return this.City;
            yield return this.Street;
        }
    }
}