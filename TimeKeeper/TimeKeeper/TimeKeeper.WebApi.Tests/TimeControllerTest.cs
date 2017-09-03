using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TimeKeeper.WebApi.Controllers;
using TimeKeeper.Domain.Models;
using TimeKeeper.Domain.Abstract;
using TimeKeeper.WebApi.Infrastructure;
using TimeKeeper.WebApi.Models.DTO;

namespace TimeKeeper.WebApi.Tests
{
    /// <summary>
    /// Summary description for TimeControllerTest
    /// </summary>
    [TestClass]
    public class TimeControllerTest
    {
        public TimeControllerTest()
        {
           
        }



        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void CalculateHoursCorrect()
        {
            TimeController tc = new TimeController();

            Time t = new Time { Id = 1, Project_Id = 1, Date = DateTime.Now, TimeStart = new DateTime(2017, 08, 26, 08, 00, 00), TimeEnd = new DateTime(2017, 08, 26, 10, 00, 00), IsInvoiced = false, Description = "Test description" };

            var expected = 2;
            var actual = tc.CalculateProjectHours(t);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateHoursIncorrect()
        {
            TimeController tc = new TimeController();

            Time t = new Time { Id = 1, Project_Id = 1, Date = DateTime.Now, TimeStart = new DateTime(2017, 08, 26, 08, 00, 00), TimeEnd = new DateTime(2017, 08, 26, 10, 00, 00), IsInvoiced = false, Description = "Test description" };

            var expected = 3;
            var actual = tc.CalculateProjectHours(t);

            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void TimeDTOToEntityValid()
        {
            DTOToEntity dte = new DTOToEntity();

            TimeDTO expected = new TimeDTO { Id = 1, Project_Id = 1, Date = DateTime.Now, TimeStart = new DateTime(2017, 08, 26, 08, 00, 00), TimeEnd = new DateTime(2017, 08, 26, 10, 00, 00), IsInvoiced = false, Description = "Test description" };

            var actual = dte.TimeDTOToEntity(expected);

            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Project_Id, actual.Project_Id);
            Assert.AreEqual(expected.Description, actual.Description);
            Assert.AreEqual(expected.Date, actual.Date);
            Assert.AreEqual(expected.TimeStart, actual.TimeStart);
            Assert.AreEqual(expected.TimeEnd, actual.TimeEnd);
            Assert.AreEqual(expected.IsInvoiced, actual.IsInvoiced);
        }

        [TestMethod]
        public void EntityToTimeDTOValid()
        {
            EntityToDTO etd = new EntityToDTO();

            Time expected = new Time { Id = 1, Project_Id = 1, Date = DateTime.Now, TimeStart = new DateTime(2017, 08, 26, 08, 00, 00), TimeEnd = new DateTime(2017, 08, 26, 10, 00, 00), IsInvoiced = false, Description = "Test description" };

            var actual = etd.TimeEntityToDTO(expected);

            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Project_Id, actual.Project_Id);
            Assert.AreEqual(expected.Description, actual.Description);
            Assert.AreEqual(expected.Date, actual.Date);
            Assert.AreEqual(expected.TimeStart, actual.TimeStart);
            Assert.AreEqual(expected.TimeEnd, actual.TimeEnd);
            Assert.AreEqual(expected.IsInvoiced, actual.IsInvoiced);
        }
    }
}
