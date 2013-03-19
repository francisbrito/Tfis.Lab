using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tfis.Lab.Hw.First.Tests
{
    [TestClass]
    public class DateTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DayShouldNotBeLowerThanOne()
        {
            var date = new Date(-1, 1, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DayShouldNotBeGreaterThanThrityOne()
        {
            var date = new Date(32, 1, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MonthShouldNotBeLowerThanOne()
        {
            var date = new Date(1, -1, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MonthShouldNotBeGreaterThanTwelve()
        {
            var date = new Date(1, 13, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void YearShouldNotBeLowerThanOne()
        {
            var date = new Date(1, 1, -1);
        }

        [TestMethod]
        public void DateShouldDefaultToCurrentDate()
        {
            var date = new Date();

            var now = DateTime.Now;

            Assert.AreEqual(now.Day, date.Day);
            Assert.AreEqual(now.Month, date.Month);
            Assert.AreEqual(now.Year, date.Year);
        }

        [TestMethod]
        public void DateToStringShouldReturnFormattedString()
        {
            var date = new Date(13, 10, 1995);

            var toString = "13 de octubre de 1995";

            Assert.IsTrue(date.ToString() == toString);

            var date2 = new Date();

            Assert.IsFalse(date.ToString() == date2.ToString());
        }

        [TestMethod]
        public void DateShouldBeComparable()
        {
            var d1 = new Date();
            var d2 = new Date(21, 11, 1995);

            Assert.AreEqual(-1, d2.Compare(d1));
            Assert.AreEqual(1, d1.Compare(d2));
            Assert.AreEqual(0, d1.Compare(d1));
        }

        [TestMethod]
        public void DateShouldTellWhetherIsALeapYearOrNot()
        {
            var d1 = new Date(1, 1, 2000);
            var d2 = new Date(1, 1, 1994);
            var d3 = new Date(18, 3, 2013);

            Assert.IsTrue(Date.IsLeapYear(d1));
            Assert.IsFalse(Date.IsLeapYear(d2));
            Assert.IsFalse(Date.IsLeapYear(d3));
        }

        [TestMethod]
        public void DateShouldReturnTheNumberOfDaysInMonth()
        {
            int daysInAugust = 31;

            Assert.AreEqual(daysInAugust, Date.GetDaysInMonth(8));

            Assert.AreEqual(daysInAugust, Date.GetDaysInMonth("agosto"));
        }

        [TestMethod]
        public void DateShouldProvideFactoryMethod()
        {
            var d1 = new Date(10, 8, 1994);
            var d2 = Date.Create(10, 8, 1994);

            Assert.AreEqual(d1, d2);
        }
    }
}
