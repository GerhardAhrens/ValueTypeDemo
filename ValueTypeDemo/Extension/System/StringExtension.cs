//-----------------------------------------------------------------------
// <copyright file="StringExtension.cs" company="Lifeprojects.de">
//     Class: StringExtension
//     Copyright © Lifeprojects.de 2021
// </copyright>
//
// <author>Gerhard Ahrens - Lifeprojects.de</author>
// <email>gerhard.ahrens@lifeprojects.de</email>
// <date>29.11.2021</date>
//
// <summary>
// Klasse für String Extension
// </summary>
//-----------------------------------------------------------------------

namespace System
{
    using global::System.Linq;
    using global::System.Text.RegularExpressions;

    internal static class StringExtension
    {
        public static string SoundEx(this string @this)
        {
            return Soundex.Generate(@this);
        }

        private static class Soundex
        {
            public const string Empty = "0000";

            private static readonly Regex Sanitiser = new Regex(@"[^A-Z]", RegexOptions.Compiled);
            private static readonly Regex CollapseRepeatedNumbers = new Regex(@"(\d)?\1*[WH]*\1*", RegexOptions.Compiled);
            private static readonly Regex RemoveVowelSounds = new Regex(@"[AEIOUY]", RegexOptions.Compiled);

            public static string Generate(string phrase)
            {
                phrase = Sanitiser.Replace((phrase ?? string.Empty).ToUpper(), string.Empty);

                if (string.IsNullOrEmpty(phrase))
                {
                    return Empty;
                }

                // Convert consonants to numerical representation
                string numericalValue = Numify(phrase);

                // Remove repeated numberics (characters of the same sound class), even if separated by H or W
                numericalValue = CollapseRepeatedNumbers.Replace(numericalValue, @"$1");

                if (numericalValue.Length > 0 && numericalValue[0] == GetChar(phrase[0]))
                {
                    numericalValue = numericalValue.Substring(1);
                }

                numericalValue = RemoveVowelSounds.Replace(numericalValue, string.Empty);

                // Concatenate, pad and trim to ensure X### format.
                return $"{phrase[0]}{numericalValue}".PadRight(4, '0').Substring(0, 4);
            }

            private static string Numify(string Phrase)
            {
                return new string(Phrase.ToCharArray().Select(GetChar).ToArray());
            }

            private static char GetChar(char Character)
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
