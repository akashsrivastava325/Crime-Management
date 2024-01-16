using System;

namespace CrimeAnalysisReportingSystem.Exceptions
{
    public class IncidentNumberNotFoundException : Exception
    {
        public IncidentNumberNotFoundException(string message) : base(message)
        {
        }
    }
}
