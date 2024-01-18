using System;
using System.Collections.Generic;
using CrimeAnalysisReportingSystem.Dao;
using CrimeAnalysisReportingSystem.Entity;
using NUnit.Framework;

namespace CrimeManagementNew.GetIncidentsInDateRange
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
        public void GetIncidentsInDateRange_ValidDateRange_ReturnsIncidents()
        {

            DateTime startDate = DateTime.Now.AddDays(-10);
            DateTime endDate = DateTime.Now;


            IEnumerable<Incident> result = crimeAnalysisService.GetIncidentsInDateRange(startDate, endDate);

            Assert.IsNotNull(result);
            foreach (var incident in result)
            {
                Assert.IsTrue(incident.IncidentDate >= startDate && incident.IncidentDate <= endDate);
            }
        }

        [Test]
        public void GetIncidentsInDateRange_InvalidDateRange_ReturnsEmptyList()
        {

            DateTime startDate = DateTime.Now.AddDays(10);
            DateTime endDate = DateTime.Now;

            IEnumerable<Incident> result = crimeAnalysisService.GetIncidentsInDateRange(startDate, endDate);

            Assert.IsNotNull(result);
            Assert.IsEmpty(result);
        }
    }
}
