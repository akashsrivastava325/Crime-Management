using System;

namespace CrimeAnalysisReportingSystem.Entity
{
    public class Victim
    {
        private int victimID;
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        private string gender;
        private string contactInformation;

        public int VictimID
        {
            get { return victimID; }
            set { victimID = value; }
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

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public string ContactInformation
        {
            get { return contactInformation; }
            set { contactInformation = value; }
        }

        // Default constructor
        public Victim()
        {
        }

        // Parameterized constructor
        public Victim(int victimID, string firstName, string lastName, DateTime dateOfBirth,
                       string gender, string contactInformation)
        {
            this.victimID = victimID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
            this.gender = gender;
            this.contactInformation = contactInformation;
        }
    }
}
