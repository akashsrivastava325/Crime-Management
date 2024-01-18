using System;
using System.Collections.Generic;
using CrimeAnalysisReportingSystem.Dao;
using CrimeAnalysisReportingSystem.Entity;
using NUnit.Framework;

namespace CrimeManagementNew.Tests
{
    [TestFixture]
    public class CrimeAnalysisServiceTests
    {
        private ICrimeAnalysisService crimeAnalysisService;

        [SetUp]
        public void Setup()
        {
            crimeAnalysisService = new CrimeAnalysisServiceImpl();
        }

        [Test]
        public void CreateIncident_ValidIncident_ReturnsTrue()
        {

            Incident testIncident = new Incident
            {
                IncidentType = "TestType",
                IncidentDate = DateTime.Now,
                Location = "TestLocation",
                Description = "TestDescription",
                Status = "Open",
                VictimID = 1, 
                SuspectID = 1 
            };


            bool result = crimeAnalysisService.CreateIncident(testIncident);


            Assert.IsTrue(result);
        }

        [Test]
        public void Invalid_TestCase()
        {
            Incident testIncident = new Incident
            {
                IncidentType = "TestType",
                IncidentDate = DateTime.Now,
                Location = "TestLocation",
                Description = "TestDescription",
                Status = "Open",
                VictimID = 1
            };


            bool result = crimeAnalysisService.CreateIncident(testIncident);


            Assert.IsFalse (result);
        }

    }
}
