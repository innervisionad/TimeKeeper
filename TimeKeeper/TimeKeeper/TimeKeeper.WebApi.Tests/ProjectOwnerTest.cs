using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeKeeper.Controllers;
using TimeKeeper.WebApi.Infrastructure;
using TimeKeeper.WebApi.Models.DTO;

namespace TimeKeeper.WebApi.Tests
{
    /// <summary>
    /// Summary description for ProjectOwnerTest
    /// </summary>
    [TestClass]
    public class ProjectOwnerTest
    {
        public ProjectOwnerTest()
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
        public void OwnerDTOToEntityExistingValid()
        {
            ProjectOwnerController poc = new ProjectOwnerController();

            DTOToEntity dte = new DTOToEntity();

            ProjectOwnerDTO expected = new ProjectOwnerDTO { Id=1, Project_Id=1, Name="Test", PhoneNumber="00000 000000", AddressLine1="address 1", AddressLine2="address 2", Town="town", County="county", PostCode="postcode"  };

            var actual = dte.OwnerDTOToEntity(expected);

            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Project_Id, actual.Project_Id);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.PhoneNumber, actual.PhoneNumber);
            Assert.AreEqual(expected.AddressLine1, actual.AddressLine1);
            Assert.AreEqual(expected.AddressLine2, actual.AddressLine2);
            Assert.AreEqual(expected.Town, actual.Town);
            Assert.AreEqual(expected.County, actual.County);
            Assert.AreEqual(expected.PostCode, actual.PostCode);

        }

        [TestMethod]
        public void OwnerDTOToEntityNewValid()
        {
            ProjectOwnerController poc = new ProjectOwnerController();

            DTOToEntity dte = new DTOToEntity();

            ProjectOwnerDTO expected = new ProjectOwnerDTO { Name = "Test", PhoneNumber = "00000 000000", AddressLine1 = "address 1", AddressLine2 = "address 2", Town = "town", County = "county", PostCode = "postcode" };

            var expectedId = 1;
            var expectedProject_id = 1;
            var actual = dte.OwnerDTOToEntity(expected);

            Assert.AreNotEqual(expectedId, actual.Id);
            Assert.AreNotEqual(expectedProject_id, actual.Project_Id);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.PhoneNumber, actual.PhoneNumber);
            Assert.AreEqual(expected.AddressLine1, actual.AddressLine1);
            Assert.AreEqual(expected.AddressLine2, actual.AddressLine2);
            Assert.AreEqual(expected.Town, actual.Town);
            Assert.AreEqual(expected.County, actual.County);
            Assert.AreEqual(expected.PostCode, actual.PostCode);

        }

    }
}
