using System;

namespace CrimeAnalysisReportingSystem.Entity
{
    public class Evidence
    {
        private int evidenceID;
        private string description;
        private string locationFound;
        private int incidentID;

        public int EvidenceID
        {
            get { return evidenceID; }
            set { evidenceID = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string LocationFound
        {
            get { return locationFound; }
            set { locationFound = value; }
        }

        public int IncidentID
        {
            get { return incidentID; }
            set { incidentID = value; }
        }

        // Default constructor
        public Evidence()
        {
        }

        // Parameterized constructor
        public Evidence(int evidenceID, string description, string locationFound, int incidentID)
        {
            this.evidenceID = evidenceID;
            this.description = description;
            this.locationFound = locationFound;
            this.incidentID = incidentID;
        }
    }
}
