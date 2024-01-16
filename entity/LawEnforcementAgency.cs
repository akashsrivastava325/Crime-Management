using System;

namespace CrimeAnalysisReportingSystem.Entity
{
    public class LawEnforcementAgency
    {
        private int agencyID;
        private string agencyName;
        private string jurisdiction;
        private string contactInformation;

        public int AgencyID
        {
            get { return agencyID; }
            set { agencyID = value; }
        }

        public string AgencyName
        {
            get { return agencyName; }
            set { agencyName = value; }
        }

        public string Jurisdiction
        {
            get { return jurisdiction; }
            set { jurisdiction = value; }
        }

        public string ContactInformation
        {
            get { return contactInformation; }
            set { contactInformation = value; }
        }

        // Default constructor
        public LawEnforcementAgency()
        {
        }

        // Parameterized constructor
        public LawEnforcementAgency(int agencyID, string agencyName, string jurisdiction, string contactInformation)
        {
            this.agencyID = agencyID;
            this.agencyName = agencyName;
            this.jurisdiction = jurisdiction;
            this.contactInformation = contactInformation;
        }
    }
}
