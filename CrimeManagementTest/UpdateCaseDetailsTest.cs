using System;
using CrimeAnalysisReportingSystem.Dao;
using CrimeAnalysisReportingSystem.Entity;
using NUnit.Framework;

namespace CrimeManagementNew.Testss
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
        public void UpdateCaseDetails_ValidCase_ReturnsTrue()
        {
 
            Case existingCase = new Case
            {
                CaseID = 1, 
                CaseDescription = "ExistingCaseDescription",
                IncidentID = 1 
            };


            bool result = crimeAnalysisService.UpdateCaseDetails(existingCase);

            Assert.IsTrue(result);
        }

        [Test]
        public void UpdateCaseDetails_InvalidCase_ReturnsFalse()
        {
           
            Case nonExistingCase = new Case
            {
                CaseID = 999, 
                CaseDescription = "NonExistingCaseDescription",
                IncidentID = 999  
            };

            bool result = crimeAnalysisService.UpdateCaseDetails(nonExistingCase);

            Assert.IsFalse(result);
        }

        [Test]
        public void UpdateCaseDetails_NullCase_ReturnsFalse()
        {
          
            Case nullCase = null;

            bool result = crimeAnalysisService.UpdateCaseDetails(nullCase);

       
            Assert.IsFalse(result);
        }
    }
}
