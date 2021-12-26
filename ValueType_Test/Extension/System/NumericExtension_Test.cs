//-----------------------------------------------------------------------
// <copyright file="ValueTypeBase_Test.cs" company="Lifeprojects.de">
//     Class: ValueTypeBase_Test
//     Copyright © Lifeprojects.de 2021
// </copyright>
//
// <author>Gerhard Ahrens - Lifeprojects.de</author>
// <email>gerhard.ahrens@lifeprojects.de</email>
// <date>13.12.2021</date>
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
    using System.Linq;
    using System.Collections.Generic;
    using System.Reflection;

    [TestClass]
    public class NumericExtension_Test : BaseTest
    {
        [TestInitialize]
        public void Initialize()
        {
        }

        public NumericExtension_Test()
        {
        }

        [TestMethod]
        public void IsNumeric()
        {
            object value = 100;
            Assert.IsTrue(value.IsNumeric());

            object text = "Gerhard";
            Assert.IsFalse(text.IsNumeric());
        }

        [TestMethod]
        public void IsBetween()
        {
            Assert.IsTrue(100.IsBetween(99, 101));
            Assert.IsTrue("Gerhard".IsBetween("X", "x"));
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
