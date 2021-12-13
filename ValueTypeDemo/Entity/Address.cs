
namespace EasyPrototyping.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Address : IEquatable<Address>, IComparable<Address>
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

        #region Implementation of IEquatable<Address>
        public bool Equals(Address other)
        {
            return this.Country == other?.Country && this.Zip == other?.Zip && this.City == other?.City && this.Street == other?.Street;
        }

        public override bool Equals(object @this)
        {
            if (ReferenceEquals(null, @this))
            {
                return false;
            }

            return @this is Address && Equals((Address)@this);
        }
        #endregion Implementation of IEquatable<Address>

        #region Implementation of IComparable<Address>
        public int CompareTo(Address other) => this.Country.CompareTo(other.Country) 
            & this.Zip.CompareTo(other.Zip) 
            & this.City.CompareTo(other.City)
            & this.Street.CompareTo(other.Street);

        #endregion Implementation of IComparable<Address>

        #region Implementation of override methodes
        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }

        public override string ToString()
        {
            return $"{this.Country},{this.Zip},{this.City};{this.Street}";
        }
        #endregion Implementation of override methodes

        #region Implementation of overload operators
        public static bool operator ==(Address a, Address b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Address a, Address b)
        {
            return !(a == b);
        }
        #endregion Implementation of overload operators

        private IEnumerable<object?> GetEqualityComponents()
        {
            yield return this.Country;
            yield return this.Zip;
            yield return this.City;
            yield return this.Street;
        }
    }
}