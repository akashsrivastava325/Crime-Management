using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using CrimeAnalysisReportingSystem.Entity;
using CrimeAnalysisReportingSystem.Exceptions;
using CrimeAnalysisReportingSystem.Util;

namespace CrimeAnalysisReportingSystem.Dao
{
    public class CrimeAnalysisServiceImpl : ICrimeAnalysisService
    {
        private SqlConnection connection;
        //public string connectionString = "Data Source=DESKTOP-G6RG569\\SQLEXPRESS;Initial Catalog=CrimeManagement;Integrated Security=True;TrustServerCertificate=True\r\n";

        public SqlConnection connectionValue; //this works but not working right now.

        public CrimeAnalysisServiceImpl()
        {
            connectionValue = DBConnection.GetConnection();
            connection = DBConnection.GetConnection();

            //connection.ConnectionString = connectionValue;
        }

        public bool CreateIncident(Incident incident)
        {
            try
            {
                // Check if the provided VictimID exists in the Victims table
                if (!VictimExistsInDatabase(incident.VictimID))
                {
                    Console.WriteLine($"Error creating incident: Victim with ID {incident.VictimID} does not exist in the database.");
                    return false;
                }
                if (!SuspectExistsInDatabase(incident.SuspectID))
                {
                    Console.WriteLine($"Error creating incident: Suspect with ID {incident.SuspectID} does not exist in the database.");
                    return false;
                }

                using (SqlCommand command = new SqlCommand("INSERT INTO Incidents (IncidentType, IncidentDate, Location, Description, Status, VictimID, SuspectID) VALUES (@IncidentType, @IncidentDate, @Location, @Description, @Status, @VictimID, @SuspectID)", connection))
                {
                    command.Parameters.AddWithValue("@IncidentType", incident.IncidentType);
                    command.Parameters.AddWithValue("@IncidentDate", incident.IncidentDate);
                    command.Parameters.AddWithValue("@Location", incident.Location);
                    command.Parameters.AddWithValue("@Description", incident.Description);
                    command.Parameters.AddWithValue("@Status", incident.Status);
                    command.Parameters.AddWithValue("@VictimID", incident.VictimID);
                    command.Parameters.AddWithValue("@SuspectID", incident.SuspectID);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating incident: {ex.Message}");
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        private bool VictimExistsInDatabase(int victimId)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Victims WHERE VictimID = @VictimID", connection))
                {
                    command.Parameters.AddWithValue("@VictimID", victimId);

                    connection.Open();
                    int rowCount = (int)command.ExecuteScalar();
                    return rowCount > 0;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log the error, throw custom exception)
                Console.WriteLine($"Error checking if victim exists in the database: {ex.Message}");
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        private bool SuspectExistsInDatabase(int suspectID)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Suspects WHERE SuspectID = @SuspectID", connection))
                {
                    command.Parameters.AddWithValue("@SuspectID", suspectID);

                    connection.Open();
                    int rowCount = (int)command.ExecuteScalar();
                    return rowCount > 0;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log the error, throw custom exception)
                Console.WriteLine($"Error checking if suspect exists in the database: {ex.Message}");
                return false;
            }
            finally
            {
                connection.Close();
            }
        }


        public bool UpdateIncidentStatus(int incidentId, string status)
        {
            try
            {
                    if (!IncidentExistsInDatabase(incidentId))
                    {
                        throw new IncidentNumberNotFoundException($"Incident with ID {incidentId} not found in the database.");
                    }

                    using (SqlCommand command = new SqlCommand("UPDATE Incidents SET Status = @Status WHERE IncidentID = @IncidentID", connection))
                    {
                        command.Parameters.AddWithValue("@Status", status);
                        command.Parameters.AddWithValue("@IncidentID", incidentId);
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating incident status: {ex.Message}");
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool IncidentExistsInDatabase(int incidentId)
        {
            try
            {

                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Incidents WHERE IncidentID = @IncidentID", connection))
                {
                    command.Parameters.AddWithValue("@IncidentID", incidentId);

                    connection.Open();
                    int rowCount = (int)command.ExecuteScalar();

                    return rowCount > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking if incident exists in the database: {ex.Message}");
                return false;
            }
        }


        public IEnumerable<Incident> GetIncidentsInDateRange(DateTime startDate, DateTime endDate)
        {
            try
            {
                    List<Incident> incidents = new List<Incident>();

                    using (SqlCommand command = new SqlCommand("SELECT * FROM Incidents WHERE IncidentDate BETWEEN @StartDate AND @EndDate", connection))
                    {
                        command.Parameters.AddWithValue("@StartDate", startDate);
                        command.Parameters.AddWithValue("@EndDate", endDate);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                incidents.Add(MapReaderToIncident(reader));
                            }
                        }
                    }

                    return incidents;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving incidents in date range: {ex.Message}");
                return null;
            }
            finally
            {
                connection.Close();
            }
        }


        public IEnumerable<Incident> SearchIncidents(string criteria)
        {
            try
            {
                        List<Incident> incidents = new List<Incident>();

                        using (SqlCommand command = new SqlCommand("SELECT * FROM Incidents WHERE IncidentType LIKE @Criteria OR Location LIKE @Criteria OR Description LIKE @Criteria", connection))
                        {
                            command.Parameters.AddWithValue("@Criteria", "%" + criteria + "%");

                            connection.Open();
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    incidents.Add(MapReaderToIncident(reader));
                                }

                            }
                        }

                        return incidents;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error searching incidents: {ex.Message}");
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        public Case CreateCase(string caseDescription, int incidentId)
        {
            try
            {
                // Check if the provided IncidentID exists in the Incidents table
                if (!IncidentExistInDatabase(incidentId))
                {
                    Console.WriteLine($"Error creating case: Incident with ID {incidentId} does not exist in the database.");
                    return null;
                }

                using (SqlCommand command = new SqlCommand("INSERT INTO Cases (CaseDescription, IncidentID) VALUES (@CaseDescription, @IncidentID); SELECT SCOPE_IDENTITY();", connection))
                {
                    command.Parameters.AddWithValue("@CaseDescription", caseDescription);
                    command.Parameters.AddWithValue("@IncidentID", incidentId);

                    connection.Open();
                    int caseId = Convert.ToInt32(command.ExecuteScalar());

                    return new Case(caseId, caseDescription, incidentId);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating case: {ex.Message}");
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        private bool IncidentExistInDatabase(int incidentId)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Incidents WHERE IncidentID = @IncidentID", connection))
                {
                    command.Parameters.AddWithValue("@IncidentID", incidentId);

                    connection.Open();
                    int rowCount = (int)command.ExecuteScalar();
                    return rowCount > 0;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log the error, throw custom exception)
                Console.WriteLine($"Error checking if incident exists in the database: {ex.Message}");
                return false;
            }
            finally
            {
                connection.Close();
            }
        }



        public Case GetCaseDetails(int caseId)
        {
            try
            {
                    using (SqlCommand command = new SqlCommand("SELECT * FROM Cases WHERE CaseID = @CaseID", connection))
                    {
                        command.Parameters.AddWithValue("@CaseID", caseId);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                        if (reader.Read())
                            {
                                return MapReaderToCase(reader);
                            }
                            return null;
                        }
                        
                    }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving case details: {ex.Message}");
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        private Case MapReaderToCase(SqlDataReader reader)
        {
            
            int caseId = Convert.ToInt32(reader["CaseID"]);
            string caseDescription = reader["CaseDescription"].ToString();
            int incidentId = Convert.ToInt32(reader["IncidentID"]);

            return new Case(caseId, caseDescription, incidentId);
        }


        public bool UpdateCaseDetails(Case updatedCase)
        {
            try
            {
                    using (SqlCommand command = new SqlCommand("UPDATE Cases SET CaseDescription = @CaseDescription WHERE CaseID = @CaseID", connection))
                    {
                        command.Parameters.AddWithValue("@CaseDescription", updatedCase.CaseDescription);
                        command.Parameters.AddWithValue("@CaseID", updatedCase.CaseID);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating case details: {ex.Message}");
                return false;
            }
            finally
            {
                connection.Close();
            }
        }


        public IEnumerable<Case> GetAllCases()
        {
            List<Case> cases = new List<Case>();

            try
            {
                    using (SqlCommand command = new SqlCommand("SELECT * FROM Cases", connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Case caseObj = MapReaderToCase(reader);
                                cases.Add(caseObj);
                            }
                        }
                    }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"Error retrieving all cases: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }

            return cases;
        }


        public Incident GetIncidentById(int incidentId)
        {
            try
            {
                if (!IncidentExistsInDatabase(incidentId))
                {
                    Console.WriteLine($"Incident with ID {incidentId} does not exist in the database.");
                    return null;
                }

                using (SqlCommand command = new SqlCommand("SELECT * FROM Incidents WHERE IncidentID = @IncidentID", connection))
                {
                    command.Parameters.AddWithValue("@IncidentID", incidentId);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapReaderToIncident(reader);
                        }
                        return null;
                       
                    }
                    
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"Error retrieving incident: {ex.Message}");
                return null;
            }
            finally
            {
                connection.Close();
            }
        }


        // Helper method to map data from SqlDataReader to Incident object
        private Incident MapReaderToIncident(SqlDataReader reader)
        {
            return new Incident
            {
                IncidentID = Convert.ToInt32(reader["IncidentID"]),
                IncidentType = Convert.ToString(reader["IncidentType"]),
                IncidentDate = Convert.ToDateTime(reader["IncidentDate"]),
                Location = Convert.ToString(reader["Location"]),
                Description = Convert.ToString(reader["Description"]),
                Status = Convert.ToString(reader["Status"]),
                VictimID = Convert.ToInt32(reader["VictimID"]),
                SuspectID = Convert.ToInt32(reader["SuspectID"])

            };
        }

    }
}
