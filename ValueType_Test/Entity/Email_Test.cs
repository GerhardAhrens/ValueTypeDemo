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

    [TestClass]
    public class Email_Test : BaseTest
    {
        [TestInitialize]
        public void Initialize()
        {
        }

        public Email_Test()
        {
        }

        [TestMethod]
        public void CreateEmptyObject()
        {
            Email email = new Email();
            Assert.IsNotNull(email);
            Assert.IsFalse(email.IsConfirmed);
        }

        [TestMethod]
        public void CreateObjectWrongMailAdress()
        {
            Email email = new Email("gerhard.ahrens@lifeprojects");
            Assert.IsNotNull(email);
            Assert.IsFalse(email.IsConfirmed);
        }

        [TestMethod]
        public void CreateObjectMailAdressOK()
        {
            Email email = new Email("gerhard.ahrens@lifeprojects.de");
            Assert.IsNotNull(email);
            Assert.IsTrue(email.IsConfirmed);
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
