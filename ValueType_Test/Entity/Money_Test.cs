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
    public class Money_Test : BaseTest
    {
        [TestInitialize]
        public void Initialize()
        {
        }

        public Money_Test()
        {
        }

        [TestMethod]
        public void CreateCurrencyA()
        {
            Money currencyEUR = new Money(100);
            Assert.IsTrue(currencyEUR.ToString() == "100,00 €");
        }

        [TestMethod]
        public void CreateCurrencyB()
        {
            Money currencyEUR = new Money(100.55M);
            Assert.IsTrue(currencyEUR.ToString() == "100,55 €");
        }

        [TestMethod]
        public void CreateCurrencyC()
        {
            Money currencyEUR = new Money(100.55M,"ß");
            Assert.IsTrue(currencyEUR.ToString() == "100,55 ß");
        }

        [TestMethod]
        public void CreateCurrencyD()
        {
            Money currencyEUR = new Money(100.55M);
            Assert.IsTrue(currencyEUR.ToString() == "100,55 €");
            Assert.IsTrue(currencyEUR.Units == 100);
            Assert.IsTrue(currencyEUR.DecimalFraction == 55);
        }

        [TestMethod]
        public void CreateBirthdayWithCultureInfo()
        {
            CultureInfo ci = CultureInfo.CurrentCulture;
            Money currencyEUR = new Money(100.99M, ci);
            Assert.IsTrue(currencyEUR.ToString() == "100,99 €");
        }

        [TestMethod]
        public void CreateObjectWithEqualsOperator()
        {
            Money currencyA = new Money(100.25M);
            Money currencyB = new Money(100.25M);
            Assert.IsTrue(currencyA == currencyB);
        }

        [TestMethod]
        public void CreateObjectWithEquals()
        {
            Money currencyA = new Money(100.25M);
            Money currencyB = new Money(100.25M);
            Assert.IsTrue(currencyA.Equals(currencyB));
        }

        [TestMethod]
        public void CreateObjectWithNotEquals()
        {
            Money currencyA = new Money(101.25M);
            Money currencyB = new Money(100.25M);
            Assert.IsFalse(currencyA.Equals(currencyB));
        }

        [TestMethod]
        public void CurrencyAddA()
        {
            Money currencyA = new Money(100.25M);
            Money currencyB = new Money(100.25M);
            Money currencySum = currencyA + currencyB;
            Assert.IsTrue(currencySum.ToDecimal() == 200.50M);
        }

        [TestMethod]
        public void CurrencyAddB()
        {
            Money currency = new Money(100.25M);
            Money currencySum = currency + 100.25M;
            Assert.IsTrue(currencySum.ToDecimal() == 200.50M);
        }

        [TestMethod]
        public void FullHundredRoundDown()
        {
            Money currency = new Money(125.55M);
            Money fullCurrency = currency.FullHundredRoundDown();
            Assert.IsTrue(fullCurrency.ToDecimal() == 100);
        }

        [TestMethod]
        public void FullHundredRoundUp()
        {
            Money currency = new Money(155.55M);
            Money fullCurrency = currency.FullHundredRoundUp();
            Assert.IsTrue(fullCurrency.ToDecimal() == 200);
        }

        [TestMethod]
        public void ToBrutto()
        {
            Money currency = new Money(100);
            Money result = currency.ToBrutto(19);
            Assert.IsTrue(result.Value == 119);
        }

        [TestMethod]
        public void ToNetto()
        {
            Money currency = new Money(119);
            Money result = currency.ToNetto(19);
            Assert.IsTrue(result.Value == 100);
        }

        [TestMethod]
        public void MehrwertSteuerBetrag()
        {
            Money currency = new Money(119);
            decimal result = currency.MehrwertSteuerBetrag(19);
            Assert.IsTrue(result == 19);
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
                Money currency = new Money(100.25M);
                Money currencySum = currency / 0;
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetType() == typeof(DivideByZeroException));
            }
        }
    }
}
