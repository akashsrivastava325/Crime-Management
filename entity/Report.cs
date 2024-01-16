using System;

namespace CrimeAnalysisReportingSystem.Entity
{
    public class Report
    {
        private int reportID;
        private int incidentID; // Foreign Key, linking to Incidents
        private int reportingOfficerID; // Foreign Key, linking to Officers
        private DateTime reportDate;
        private string reportDetails;
        private string status;

        // Default constructor
        public Report()
        {
        }

        // Parameterized constructor
        public Report(int reportID, int incidentID, int reportingOfficerID, DateTime reportDate,
                      string reportDetails, string status)
        {
            this.reportID = reportID;
            this.incidentID = incidentID;
            this.reportingOfficerID = reportingOfficerID;
            this.reportDate = reportDate;
            this.reportDetails = reportDetails;
            this.status = status;
        }

        public int ReportID
        {
            get { return reportID; }
            set { reportID = value; }
        }

        public int IncidentID
        {
            get { return incidentID; }
            set { incidentID = value; }
        }

        public int ReportingOfficerID
        {
            get { return reportingOfficerID; }
            set { reportingOfficerID = value; }
        }

        public DateTime ReportDate
        {
            get { return reportDate; }
            set { reportDate = value; }
        }

        public string ReportDetails
        {
            get { return reportDetails; }
            set { reportDetails = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
