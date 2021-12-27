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

    using ValueTypeLibrary.Core;

    public class Address : ValueObjectBase
    {
        public Address(string country, string zip, string city, string street)
        {
            country.IsArgumentEmptyOrNull(nameof(country));
            zip.IsArgumentEmptyOrNull(nameof(zip));
            city.IsArgumentEmptyOrNull(nameof(city));
            street.IsArgumentEmptyOrNull(nameof(street));

            this.Country = country;
            this.Zip = zip;
            this.City = city;
            this.Street = street;
            this.StreetAdd = string.Empty;
        }

        public Address(string country, string zip,string city, string street, string streetAdd)
        {
            country.IsArgumentEmptyOrNull(nameof(country));
            zip.IsArgumentEmptyOrNull(nameof(zip));
            city.IsArgumentEmptyOrNull(nameof(city));
            street.IsArgumentEmptyOrNull(nameof(street));
            streetAdd.IsArgumentEmptyOrNull(nameof(streetAdd));

            this.Country = country;
            this.Zip = zip;
            this.City = city;
            this.Street = street;
            this.StreetAdd = streetAdd;
        }

        public string Country { get; }

        public string Zip { get; }

        public string City { get; }

        public string Street { get;  }

        public string StreetAdd { get; }

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
            bool result = false;

            if (a?.Country == b?.Country && a?.Zip == b?.Zip && a?.City == b?.City && a?.Street == b?.Street && a?.StreetAdd == b?.StreetAdd)
            {
                result = true;
            }

            return result;
        }

        public static bool operator !=(Address a, Address b)
        {
            bool result = false;

            if (a?.Country != b?.Country || a?.Zip != b?.Zip || a?.City != b?.City || a?.Street != b?.Street || a?.StreetAdd != b?.StreetAdd)
            {
                result = true;
            }

            return result;
        }
        #endregion Implementation of overload operators

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return this.Country;
            yield return this.Zip;
            yield return this.City;
            yield return this.Street;
            yield return this.StreetAdd;
        }
    }
}