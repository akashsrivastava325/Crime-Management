using System;
using CrimeAnalysisReportingSystem.Entity;
using System.Collections.Generic;

namespace CrimeAnalysisReportingSystem.Dao
{
    public interface ICrimeAnalysisService
    {
        // Create a new incident
        bool CreateIncident(Incident incident);

        // Update the status of an incident
        bool UpdateIncidentStatus(int incidentId, string status);

        // Get a list of incidents within a date range
        IEnumerable<Incident> GetIncidentsInDateRange(DateTime startDate, DateTime endDate);

        // Search for incidents based on various criteria
        IEnumerable<Incident> SearchIncidents(string criteria);


        // Create a new case and associate it with incidents
        Case CreateCase(string caseDescription, int incidents);

        // Get details of a specific case
        Case GetCaseDetails(int caseId);

        // Update case details
        bool UpdateCaseDetails(Case updatedCase);

        // Get a list of all cases
        IEnumerable<Case> GetAllCases();
        Incident GetIncidentById(int incidentId);
        bool IncidentExistsInDatabase(int incidentId);
    }
}
