using CrimeAnalysisReportingSystem.Dao;
using CrimeAnalysisReportingSystem.Entity;


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
    public void CreateCase_ValidCase_ReturnsCaseObject()
    {

        string caseDescription = "Test Case";
        int validIncidentId = 7; 

        Case createdCase = crimeAnalysisService.CreateCase(caseDescription, validIncidentId);

        Assert.IsNotNull(createdCase);
        Assert.AreEqual(caseDescription, createdCase.CaseDescription);
        Assert.AreEqual(validIncidentId, createdCase.IncidentID);
    }

    [Test]
    public void CreateCase_InvalidIncidentId_ReturnsNull()
    {
        string caseDescription = "Test Case";
        int invalidIncidentId = -1; 

        Case createdCase = crimeAnalysisService.CreateCase(caseDescription, invalidIncidentId);

        Assert.IsNull(createdCase);
    }

    [Test]
    public void CreateCase_NullCaseDescription_ReturnsNull()
    {
   
        string nullCaseDescription = null;
        int validIncidentId = 1;

     
        Case createdCase = crimeAnalysisService.CreateCase(nullCaseDescription, validIncidentId);

     
        Assert.IsNull(createdCase);
    }

    
}
