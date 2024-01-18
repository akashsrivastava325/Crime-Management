using NUnit.Framework;
using System;
using System.Collections.Generic;
using CrimeAnalysisReportingSystem.Dao;
using CrimeAnalysisReportingSystem.Entity;

namespace CrimeManagementNew.Test
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
        public void UpdateIncidentStatus_ValidIncidentIdAndStatus_ReturnsTrue()
        {
            // Arrange
            int incidentId = 6; 
            string status = "Closed";

            // Act
            bool result = crimeAnalysisService.UpdateIncidentStatus(incidentId, status);

            // Assert
            Assert.IsTrue(result, "UpdateIncidentStatus should return true for a valid incidentId and status.");
        }

        [Test]
        public void UpdateIncidentStatus_InvalidIncidentId_ReturnsFalse()
        {
            // Arrange
            int incidentId = -1; 
            string status = "Closed"; 

            // Act
            bool result = crimeAnalysisService.UpdateIncidentStatus(incidentId, status);

            // Assert
            Assert.IsFalse(result, "UpdateIncidentStatus should return false for an invalid incidentId.");
        }

        [Test]
        public void UpdateIncidentStatus_NullStatus_ReturnsFalse()
        {
            // Arrange
            int incidentId = 7; 
            string status = null; 

            // Act
            bool result = crimeAnalysisService.UpdateIncidentStatus(incidentId, status);

            // Assert
            Assert.IsFalse(result, "UpdateIncidentStatus should return false for a null status.");
        }
    }
}
