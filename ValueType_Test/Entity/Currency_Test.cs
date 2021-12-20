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
        public void CreateCurrency()
        {
            Currency currencyEUR = new Currency(100);
            Assert.IsTrue(currencyEUR.ToString() == "100,00 €");
        }

        [TestMethod]
        public void CreateBirthdayWithCultureInfo()
        {
            CultureInfo ci = CultureInfo.CurrentCulture;
            Currency currencyEUR = new Currency(100.99M, ci);
            Assert.IsTrue(currencyEUR.ToString() == "100,99 €");
        }

        [TestMethod]
        public void CreateObjectWithEquals()
        {
        }

        [TestMethod]
        public void CreateObjectWithNotEquals()
        {
        }

        [DataRow("", "")]
        [TestMethod]
        public void Methode_B(string input, string expected)
        {
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ExceptionTestAttribute()
        {
        }

        [TestMethod]
        public void ExceptionTest()
        {
            try
            {
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetType() == typeof(Exception));
            }
        }
    }
}
