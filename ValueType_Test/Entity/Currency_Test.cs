//-----------------------------------------------------------------------
// <copyright file="Currency_Test.cs" company="Lifeprojects.de">
//     Class: Currency_Test
//     Copyright © Lifeprojects.de 2021
// </copyright>
//
// <author>Gerhard Ahrens - Lifeprojects.de</author>
// <email>gerhard.ahrens@lifeprojects.de</email>
// <date>20.12.2021</date>
//
// <summary>
// UnitTest Class for
// </summary>
//-----------------------------------------------------------------------

namespace ValueType_Test
{
    using EasyPrototyping.Entity;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using System;
    using System.Globalization;

    [TestClass]
    public class Currency_Test : BaseTest
    {
        [TestInitialize]
        public void Initialize()
        {
        }

        public Currency_Test()
        {
        }

        [TestMethod]
        public void CreateCurrencyA()
        {
            Currency currencyEUR = new Currency(100);
            Assert.IsTrue(currencyEUR.ToString() == "100,00 €");
        }

        [TestMethod]
        public void CreateCurrencyB()
        {
            Currency currencyEUR = new Currency(100.55M);
            Assert.IsTrue(currencyEUR.ToString() == "100,55 €");
        }

        [TestMethod]
        public void CreateCurrencyC()
        {
            Currency currencyEUR = new Currency(100.55M,"ß");
            Assert.IsTrue(currencyEUR.ToString() == "100,55 ß");
        }

        [TestMethod]
        public void CreateCurrencyD()
        {
            Currency currencyEUR = new Currency(100.55M);
            Assert.IsTrue(currencyEUR.ToString() == "100,55 €");
            Assert.IsTrue(currencyEUR.Units == 100);
            Assert.IsTrue(currencyEUR.DecimalFraction == 55);
        }

        [TestMethod]
        public void CreateBirthdayWithCultureInfo()
        {
            CultureInfo ci = CultureInfo.CurrentCulture;
            Currency currencyEUR = new Currency(100.99M, ci);
            Assert.IsTrue(currencyEUR.ToString() == "100,99 €");
        }

        [TestMethod]
        public void CreateObjectWithEqualsOperator()
        {
            Currency currencyA = new Currency(100.25M);
            Currency currencyB = new Currency(100.25M);
            Assert.IsTrue(currencyA == currencyB);
        }

        [TestMethod]
        public void CreateObjectWithEquals()
        {
            Currency currencyA = new Currency(100.25M);
            Currency currencyB = new Currency(100.25M);
            Assert.IsTrue(currencyA.Equals(currencyB));
        }

        [TestMethod]
        public void CreateObjectWithNotEquals()
        {
            Currency currencyA = new Currency(101.25M);
            Currency currencyB = new Currency(100.25M);
            Assert.IsFalse(currencyA.Equals(currencyB));
        }

        [TestMethod]
        public void CurrencyAddA()
        {
            Currency currencyA = new Currency(100.25M);
            Currency currencyB = new Currency(100.25M);
            Currency currencySum = currencyA + currencyB;
            Assert.IsTrue(currencySum.ToDecimal() == 200.50M);
        }

        [TestMethod]
        public void CurrencyAddB()
        {
            Currency currency = new Currency(100.25M);
            Currency currencySum = currency + 100.25M;
            Assert.IsTrue(currencySum.ToDecimal() == 200.50M);
        }

        [TestMethod]
        public void FullHundredRoundDown()
        {
            Currency currency = new Currency(125.55M);
            Currency fullCurrency = currency.FullHundredRoundDown();
            Assert.IsTrue(fullCurrency.ToDecimal() == 100);
        }

        [TestMethod]
        public void FullHundredRoundUp()
        {
            Currency currency = new Currency(155.55M);
            Currency fullCurrency = currency.FullHundredRoundUp();
            Assert.IsTrue(fullCurrency.ToDecimal() == 200);
        }

        [TestMethod]
        public void ToBrutto()
        {
            Currency currency = new Currency(100);
            Currency result = currency.ToBrutto(19);
            Assert.IsTrue(result.Value == 119);
        }

        [TestMethod]
        public void ToNetto()
        {
            Currency currency = new Currency(119);
            Currency result = currency.ToNetto(19);
            Assert.IsTrue(result.Value == 100);
        }

        [DataRow("", "")]
        [TestMethod]
        public void Methode_B(string input, string expected)
        {
        }

        /*
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException),"Division durch 0")]
        public void DivideByZero()
        {
            Assert.ThrowsException<DivideByZeroException>(() =>
            {
                Currency currency = new Currency(100.25M);
                Currency currencySum = currency / 0;
            });
        }
        */

        [TestMethod]
        public void DivideByZero()
        {
            try
            {
                Currency currency = new Currency(100.25M);
                Currency currencySum = currency / 0;
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetType() == typeof(DivideByZeroException));
            }
        }
    }
}
