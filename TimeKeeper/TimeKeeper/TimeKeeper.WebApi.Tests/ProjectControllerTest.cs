using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeKeeper.WebApi;
using TimeKeeper.Domain;
using TimeKeeper.Domain.Models;
using System.Data.SqlClient;
using System.Data;
using TimeKeeper.Controllers;
using System.Net;
using TimeKeeper.WebApi.Infrastructure;
using TimeKeeper.WebApi.Models.DTO;

namespace TimeKeeper.WebApi.Tests
{
    [TestClass]
    public class ProjectControllerTest
    {
        public ProjectControllerTest()
        {

        }
        [TestMethod]
        public void ProjectDTOToEntityExistingValid()
        {
            ProjectController pc = new ProjectController();

            DTOToEntity dte = new DTOToEntity();

            ProjectDTO expected = new ProjectDTO { Id=1, Invoiced=false,  ProjectName="Test Project", ProjectDescription="Test Description" };
            var actual = dte.ProjectDTOToEntity(expected);

            Assert.AreNotEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.ProjectName, actual.ProjectName);
            Assert.AreEqual(expected.ProjectDescription, actual.ProjectDescription);
            Assert.AreEqual(expected.Invoiced, actual.Invoiced);
        }

        [TestMethod]
        public void ProjectDTOToEntityNewValid()
        {
            ProjectController pc = new ProjectController();

            DTOToEntity dte = new DTOToEntity();

            ProjectDTO expected = new ProjectDTO {Invoiced = false, ProjectName = "Test Project", ProjectDescription = "Test Description" };

            var expectedId = 1;
            var actual = dte.ProjectDTOToEntity(expected);

            Assert.AreEqual(expected.ProjectName, actual.ProjectName);
            Assert.AreEqual(expected.ProjectDescription, actual.ProjectDescription);
            Assert.AreEqual(expected.Invoiced, actual.Invoiced);
            Assert.AreNotEqual(expectedId, actual.Id);
        }

        [TestMethod]
        public void ProjectEntityToDTOValid()
        {
            ProjectController pc = new ProjectController();

            EntityToDTO etd = new EntityToDTO();

            Project expected = new Project { Invoiced = false, ProjectName = "Test Project", ProjectDescription = "Test Description" };

            var actual = etd.ProjectEntityToDTO(expected);

            Assert.AreEqual(expected.ProjectName, actual.ProjectName);
            Assert.AreEqual(expected.ProjectDescription, actual.ProjectDescription);
            Assert.AreEqual(expected.Invoiced, actual.Invoiced);

        }

    }
}
