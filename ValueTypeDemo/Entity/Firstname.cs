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
// Klasse für Domain ValueType Firstname
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
                this.PhoneticCode = Soundex.Generate(value);
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

        private static class Soundex
        {
            public const string Empty = "0000";

            private static readonly Regex Sanitiser = new Regex(@"[^A-Z]", RegexOptions.Compiled);
            private static readonly Regex CollapseRepeatedNumbers = new Regex(@"(\d)?\1*[WH]*\1*", RegexOptions.Compiled);
            private static readonly Regex RemoveVowelSounds = new Regex(@"[AEIOUY]", RegexOptions.Compiled);

            public static string Generate(string Phrase)
            {
                // Remove non-alphas
                Phrase = Sanitiser.Replace((Phrase ?? string.Empty).ToUpper(), string.Empty);

                // Nothing to soundex, return empty
                if (string.IsNullOrEmpty(Phrase))
                    return Empty;

                // Convert consonants to numerical representation
                var Numified = Numify(Phrase);

                // Remove repeated numberics (characters of the same sound class), even if separated by H or W
                Numified = CollapseRepeatedNumbers.Replace(Numified, @"$1");

                if (Numified.Length > 0 && Numified[0] == Numify(Phrase[0]))
                {
                    // Remove first numeric as first letter in same class as subsequent letters
                    Numified = Numified.Substring(1);
                }

                // Remove vowels
                Numified = RemoveVowelSounds.Replace(Numified, string.Empty);

                // Concatenate, pad and trim to ensure X### format.
                return string.Format("{0}{1}", Phrase[0], Numified).PadRight(4, '0').Substring(0, 4);
            }

            private static string Numify(string Phrase)
            {
                return new string(Phrase.ToCharArray().Select(Numify).ToArray());
            }

            private static char Numify(char Character)
            {
                switch (Character)
                {
                    case 'B':
                    case 'F':
                    case 'P':
                    case 'V':
                        return '1';
                    case 'C':
                    case 'G':
                    case 'J':
                    case 'K':
                    case 'Q':
                    case 'S':
                    case 'X':
                    case 'Z':
                        return '2';
                    case 'D':
                    case 'T':
                        return '3';
                    case 'L':
                        return '4';
                    case 'M':
                    case 'N':
                        return '5';
                    case 'R':
                        return '6';
                    default:
                        return Character;
                }
            }
        }
    }
}
