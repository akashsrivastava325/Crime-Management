using System;

namespace CrimeAnalysisReportingSystem.Entity
{
    public class Suspect
    {
        private int suspectID;
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        private string gender;
        private string contactInformation;

        public int SuspectID
        {
            get { return suspectID; }
            set { suspectID = value; }
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
        public Suspect()
        {
        }

        // Parameterized constructor
        public Suspect(int suspectID, string firstName, string lastName, DateTime dateOfBirth,
                        string gender, string contactInformation)
        {
            this.suspectID = suspectID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
            this.gender = gender;
            this.contactInformation = contactInformation;
        }
    }
}
