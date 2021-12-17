//-----------------------------------------------------------------------
// <copyright file="Birthday_Test.cs" company="Lifeprojects.de">
//     Class: Birthday_Test
//     Copyright © Lifeprojects.de 2021
// </copyright>
//
// <author>Gerhard Ahrens - Lifeprojects.de</author>
// <email>gerhard.ahrens@lifeprojects.de</email>
// <date>17.12.2021</date>
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
    public class Birthday_Test : BaseTest
    {
        [TestInitialize]
        public void Initialize()
        {
        }

        public Birthday_Test()
        {
        }

        [TestMethod]
        public void CreateBirthdayFromDateTime()
        {
            DateTime dt = new DateTime(1960, 6, 28);
            Birthday b = new Birthday(dt);
            Assert.IsTrue(b.GetType() == typeof(Birthday));
            Assert.IsTrue(b.ToDateTime() == new DateTime(1960, 6, 28));
        }

        [TestMethod]
        public void CreateBirthdayFromIntYMD()
        {
            Birthday b = new Birthday(1960, 6, 28);
            Assert.IsTrue(b.GetType() == typeof(Birthday));
            Assert.IsTrue(b.ToDateTime() == new DateTime(1960, 6, 28));
        }

        [TestMethod]
        public void CreateObjectWithEquals()
        {
            Birthday birthdayA = new Birthday(1960, 6, 28);
            Birthday birthdayB = new Birthday(1960, 6, 28);
            Assert.IsTrue(birthdayA == birthdayB);
        }

        [TestMethod]
        public void CreateObjectWithNotEquals()
        {
            Birthday birthdayA = new Birthday(1960, 6, 28);
            Birthday birthdayB = new Birthday(2021, 12, 17);
            Assert.IsTrue(birthdayA != birthdayB);
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
