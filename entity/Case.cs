using System;
using System.Collections.Generic;

namespace CrimeAnalysisReportingSystem.Entity
{
    public class Case
    {
        private int caseID;
        private string caseDescription;
        private int incidentID;

        // Properties
        public int CaseID
        {
            get { return caseID; }
            set { caseID = value; }
        }

        public string CaseDescription
        {
            get { return caseDescription; }
            set { caseDescription = value; }
        }

        public int IncidentID
        {
            get { return incidentID; }
            set { incidentID = value; }
        }

        // Default Constructor
        public Case() { }

        // Parameterized Constructor
        public Case(int caseID, string caseDescription, int incidentID)
        {
            this.caseID = caseID;
            this.caseDescription = caseDescription;
            this.incidentID = incidentID;
        }
    }
}
