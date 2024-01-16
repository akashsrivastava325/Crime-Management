using System;

namespace CrimeAnalysisReportingSystem.Entity
{
    public class Officer
    {
        private int officerID;
        private string firstName;
        private string lastName;
        private string badgeNumber;
        private string rank;
        private string contactInformation;
        private int agencyID;

        public int OfficerID
        {
            get { return officerID; }
            set { officerID = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string BadgeNumber
        {
            get { return badgeNumber; }
            set { badgeNumber = value; }
        }

        public string Rank
        {
            get { return rank; }
            set { rank = value; }
        }

        public string ContactInformation
        {
            get { return contactInformation; }
            set { contactInformation = value; }
        }

        public int AgencyID
        {
            get { return agencyID; }
            set { agencyID = value; }
        }

        // Default constructor
        public Officer()
        {
        }

        // Parameterized constructor
        public Officer(int officerID, string firstName, string lastName, string badgeNumber, string rank,
                        string contactInformation, int agencyID)
        {
            this.officerID = officerID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.badgeNumber = badgeNumber;
            this.rank = rank;
            this.contactInformation = contactInformation;
            this.agencyID = agencyID;
        }
    }
}
