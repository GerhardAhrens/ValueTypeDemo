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
        public void CreateEmptyObjectWithEmptyAdress()
        {
            Email email = new Email(string.Empty);
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
            Assert.IsTrue(email.Value == "gerhard.ahrens@lifeprojects.de");
            Assert.IsTrue(email.IsConfirmed);
        }

        [TestMethod]
        public void CreateObjectWithEquals()
        {
            Email emailA = new Email("gerhard.ahrens@lifeprojects.de");
            Email emailB = new Email("gerhard.ahrens@lifeprojects.de");
            Assert.IsTrue(emailA == emailB);
        }

        [TestMethod]
        public void CreateObjectWithNotEquals()
        {
            Email emailA = new Email("gerhard.ahrens@lifeprojects.de");
            Email emailB = new Email("gerhard.ahrens@musterdomain.de");
            Assert.IsFalse(emailA == emailB);
        }

        [TestMethod]
        public void CreateObjectWithClone()
        {
            Email emailA = new Email("gerhard.ahrens@lifeprojects.de");
            Email emailB = emailA.CloneTo<Email>();
            Assert.IsTrue(emailA == emailB);
        }

        [TestMethod]
        public void GetValues()
        {
            Email emailA = new Email("gerhard.ahrens@lifeprojects.de");
            IEnumerable<string> values = emailA.GetValues();
            Assert.IsNotNull(values);
            Assert.IsTrue(values.Count() == 3);
        }

        [TestMethod]
        public void GetProperties()
        {
            Email emailA = new Email("gerhard.ahrens@lifeprojects.de");
            IEnumerable<PropertyInfo> propList = emailA.GetProperties();
            Assert.IsNotNull(propList);
            Assert.IsTrue(propList.Count() == 3);
        }

        [DataRow("gerhard.ahrens@lifeprojects.de", "gerhard.ahrens@lifeprojects.de")]
        [TestMethod]
        public void EMail_ToString(string input, string expected)
        {
            Email emailA = new Email(input);
            Assert.IsTrue(emailA.ToString() == "gerhard.ahrens@lifeprojects.de");
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
