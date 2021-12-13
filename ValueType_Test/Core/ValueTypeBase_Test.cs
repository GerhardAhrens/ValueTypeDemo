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
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using System;

    [TestClass]
    public class ValueTypeBase_Test : BaseTest
    {
        [TestInitialize]
        public void Initialize()
        {
        }

        public ValueTypeBase_Test()
        {
        }

        [TestMethod]
        public void Methode_A()
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
