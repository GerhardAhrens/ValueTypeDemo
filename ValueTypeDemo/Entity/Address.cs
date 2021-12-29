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
    using System.Linq;
    using System.Collections.Generic;

    using ValueTypeLibrary.Core;

    public class Address : ValueObjectBase
    {
        public Address(string country, string zip, string city, params string[] street)
        {
            country.IsArgumentNull(nameof(country));
            zip.IsArgumentNull(nameof(zip));
            city.IsArgumentNull(nameof(city));
            street.IsArgumentNull(nameof(street));

            this.Country = country;
            this.Zip = zip;
            this.City = city;
            this.Street = street;
        }

        public string Country { get; }

        public string Zip { get; }

        public string City { get; }

        public string[] Street { get;  }

        public bool IsEmpty()
        {

            bool result = this.GetType().GetProperties()
                .Where(pi => pi.PropertyType == typeof(string))
                .Select(pi => (string)pi.GetValue(this))
                .Any(value => string.IsNullOrEmpty(value));

            return result;
        }

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
            return $"{this.Country},{this.Zip},{this.City};{string.Join(" ", this.Street)}";
        }
        #endregion Implementation of override methodes

        #region Implementation of overload operators
        public static bool operator ==(Address a, Address b)
        {
            bool result = false;

            var query = from aProp in a?.GetType().GetProperties()
                        let aValue = aProp.GetValue(a)
                        let bProp = b?.GetType().GetProperty(aProp.Name)
                        let bValue = bProp?.GetValue(b)
                        where !aValue.Equals(bValue)
                        select new { aProp.Name, aValue, bValue };

            result = query.Where(w => w.Name != "ObjectId").Count() > 0 ? false : true;

            /*
            if (a?.Country == b?.Country && a?.Zip == b?.Zip && a?.City == b?.City && a?.Street == b?.Street && a?.StreetAdd == b?.StreetAdd)
            {
                result = true;
            }
            */
            return result;
        }

        public static bool operator !=(Address a, Address b)
        {
            bool result = false;

            var query = from aProp in a?.GetType().GetProperties()
                        let aValue = aProp.GetValue(a)
                        let bProp = b?.GetType().GetProperty(aProp.Name)
                        let bValue = bProp?.GetValue(b)
                        where !aValue.Equals(bValue)
                        select new { aProp.Name, aValue, bValue };

            result = query.Where(w => w.Name != "ObjectId").Count() > 0 ? true : false;

            /*
            if (a?.Country != b?.Country || a?.Zip != b?.Zip || a?.City != b?.City || a?.Street != b?.Street || a?.StreetAdd != b?.StreetAdd)
            {
                result = true;
            }
            */
            return result;
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