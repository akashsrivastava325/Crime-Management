using System;
using System.Collections.Generic;

namespace CrimeAnalysisReportingSystem.Entity
{
    public class Incident
    {
        private int incidentID;
        private string incidentType;
        private DateTime incidentDate;
        private string location;
        private string description;
        private string status;
        private int victimID;
        private int suspectID;

        public int IncidentID
        {
            get { return incidentID; }
            set { incidentID = value; }
        }

        public string IncidentType
        {
            get { return incidentType; }
            set { incidentType = value; }
        }

        public DateTime IncidentDate
        {
            get { return incidentDate; }
            set { incidentDate = value; }
        }

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public int VictimID
        {
            get { return victimID; }
            set { victimID = value; }
        }

        public int SuspectID
        {
            get { return suspectID; }
            set { suspectID = value; }
        }

        // Default constructor
        public Incident()
        {
        }

        // Parameterized constructor
        public Incident(int incidentID, string incidentType, DateTime incidentDate, string location,
                         string description, string status, int victimID, int suspectID)
        {
            this.incidentID = incidentID;
            this.incidentType = incidentType;
            this.incidentDate = incidentDate;
            this.location = location;
            this.description = description;
            this.status = status;
            this.victimID = victimID;
            this.suspectID = suspectID;
        }
    }
}
