//-----------------------------------------------------------------------
// <copyright file="Currency.cs" company="Lifeprojects.de">
//     Class: Currency
//     Copyright © Lifeprojects.de 2021
// </copyright>
//
// <author>Gerhard Ahrens - Lifeprojects.de</author>
// <email>gerhard.ahrens@lifeprojects.de</email>
// <date>25.11.2021</date>
//
// <summary>
// Klasse für Entity ValueType Currency
// </summary>
//-----------------------------------------------------------------------

namespace EasyPrototyping.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    using ValueTypeDemo.Core;

    public class Currency : ValueObjectBase
    {
        private const decimal FractionScale = 1E9M;

        public Currency(decimal value)
        {
            this.CultureInfo = CultureInfo.CurrentCulture;
            this.Value = value;
            this.CurrencySymbol = this.CultureInfo.NumberFormat.CurrencySymbol;
            this.DecimalPlace = 2;
            this.CalcDecimalFraction();
        }

        public Currency(decimal value, int decimalPlace)
        {
            this.CultureInfo = CultureInfo.CurrentCulture;
            this.Value = value;
            this.CurrencySymbol = this.CultureInfo.NumberFormat.CurrencySymbol;
            this.DecimalPlace = decimalPlace;
            this.CalcDecimalFraction();
        }

        public Currency(decimal value, CultureInfo cultureInfo)
        {
            this.CultureInfo = cultureInfo;
            this.Value = value;
            this.CurrencySymbol = this.CultureInfo.NumberFormat.CurrencySymbol;
            this.DecimalPlace = 2;
            this.CalcDecimalFraction();
        }

        public Currency(decimal value, string currencySymbol)
        {
            this.Value = value;
            this.CurrencySymbol = currencySymbol;
            this.DecimalPlace = 2;
            this.CalcDecimalFraction();
        }

        public Currency(decimal value, int decimalPlace, string currencySymbol)
        {
            this.Value = value;
            this.CurrencySymbol = currencySymbol;
            this.DecimalPlace = decimalPlace;
            this.CalcDecimalFraction();
        }

        public decimal Value { get;}

        public int DecimalPlace { get; }

        public string CurrencySymbol { get; }

        public CultureInfo CultureInfo { get; }

        public Int64 Units { get; private set; }

        public Int32 DecimalFraction { get; private set; }

        public string DecimalSeparator
        {
            get
            {
                return this.CultureInfo.NumberFormat.CurrencyDecimalSeparator;
            }
        }

        public string NumberGroupSeparator
        {
            get
            {
                return this.CultureInfo.NumberFormat.NumberGroupSeparator;
            }
        }

        public bool IsNullOrEmpty
        {
            get
            {
                if (this.Value == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool IsNotNullOrEmpty
        {
            get
            {
                if (this.Value != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public double ToDouble()
        {
            return Convert.ToDouble(this.Value);
        }

        public decimal ToDecimal()
        {
            return Convert.ToDecimal(this.Value);
        }

        public Currency FullHundredRoundDown()
        {
            int result = Convert.ToInt32(Math.Floor(this.Value));

            int rest = result % 100;
            if (rest < 99)
            {
                return new Currency(result - rest);
            }
            else
            {
                return new Currency(result + (100 - rest));
            }
        }

        public Currency FullHundredRoundUp()
        {
            int result = Convert.ToInt32(Math.Floor(this.Value));

            int rest = result % 100;
            if (rest < 50)
            {
                return new Currency(result - rest);
            }
            else
            {
                return new Currency(result + (100 - rest));
            }
        }

        #region Implementation of overload operators
        public static bool operator ==(Currency a, Currency b)
        {
            return EqualOperator(a.Value, b.Value);
        }

        public static bool operator ==(Currency a, decimal b)
        {
            return EqualOperator(a.Value, b);
        }

        public static bool operator !=(Currency a, Currency b)
        {
            return NotEqualOperator(a.Value, b.Value);
        }

        public static bool operator !=(Currency a, decimal b)
        {
            return NotEqualOperator(a.Value, b);
        }

        public static bool operator > (Currency a, Currency b)
        {
            return GreaterThanOperator(a.Value, b.Value);
        }

        public static bool operator >(Currency a, decimal b)
        {
            return GreaterThanOperator(a.Value, b);
        }

        public static bool operator >= (Currency a, Currency b)
        {
            return GreaterThanOrEqualOperator(a.Value, b.Value);
        }

        public static bool operator >=(Currency a, decimal b)
        {
            return GreaterThanOrEqualOperator(a.Value, b);
        }

        public static bool operator < (Currency a, Currency b)
        {
            return LessThanOperator(a.Value, b.Value);
        }

        public static bool operator <(Currency a, decimal b)
        {
            return LessThanOperator(a.Value, b);
        }

        public static bool operator <=(Currency a, Currency b)
        {
            return LessThanOrEqualOperator(a.Value, b.Value);
        }

        public static bool operator <=(Currency a, decimal b)
        {
            return LessThanOrEqualOperator(a.Value, b);
        }

        public static Currency operator + (Currency a, Currency b)
        {
            return new Currency(a.Value + b.Value);
        }

        public static Currency operator +(Currency a, decimal b)
        {
            return new Currency(a.Value + b);
        }

        public static Currency operator - (Currency a, Currency b)
        {
            return new Currency(a.Value - b.Value);
        }

        public static Currency operator - (Currency a, decimal b)
        {
            return new Currency(a.Value - b);
        }

        public static Currency operator /(Currency a, Currency b)
        {
            if (b.Value > 0)
            {
                return new Currency(a.Value / b.Value);
            }
            else
            {
                throw new DivideByZeroException($"DivideByZero: Value '{a.Value}/{b.Value}' not possible! ");
            }
        }

        public static Currency operator /(Currency a, decimal b)
        {
            if (b > 0)
            {
                return new Currency(a.Value / b);
            }
            else
            {
                throw new DivideByZeroException($"DivideByZero: Value '{a.Value}/{b}' not possible! ");
            }
        }

        public static Currency operator *(Currency a, Currency b)
        {
            return new Currency(a.Value * b.Value);
        }

        public static Currency operator *(Currency a, decimal b)
        {
            return new Currency(a.Value * b);
        }

        #endregion Implementation of overload operators

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
            return $"{this.Value.ToString($"F{this.DecimalPlace}")} {this.CurrencySymbol}";
        }

        public string ToString(string format)
        {
            return this.Value.ToString(format);
        }
        #endregion Implementation of override methodes

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return this.Value;
            yield return this.CurrencySymbol;
        }

        private void CalcDecimalFraction()
        {
            this.Units = (Int64)this.Value;
            this.DecimalFraction = (int)(((decimal)this.Value % 1) * 100);

            if (this.DecimalFraction >= FractionScale)
            {
                this.Units += 1;
                this.DecimalFraction = this.DecimalFraction - (Int32)FractionScale;
            }
        }
    }
}