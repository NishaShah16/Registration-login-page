using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace NDProject.Models
{
    public class UserDetailsDAL
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

       
        public List<DropdownList> GetDropdownValues()
        {
            var programmes = new List<DropdownList>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Define the SQL query to fetch dropdown values
                    SqlCommand command = new SqlCommand("SELECT ProgrammeId, programme FROM DropdownList", connection);

                    // Open the database connection
                    connection.Open();

                    // Execute the query and read the results
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Add each record to the programmes list
                            programmes.Add(new DropdownList
                            {
                                ProgrammeId = Convert.ToInt32(reader["ProgrammeId"]),
                                programme = reader["programme"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception (you can replace this with your logging mechanism)
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return programmes;
        }





        public void AddUser(UserDetails user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Use the stored procedure Sp_UserDetails instead of a direct SQL query
                    SqlCommand cmd = new SqlCommand("Sp_UserDetails", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add parameters corresponding to the stored procedure
                    cmd.Parameters.AddWithValue("@programme", user.programme);  // Assuming DropdownId is the programmeId
                    cmd.Parameters.AddWithValue("@NeetRollNo", user.NeetRollNo);
                    cmd.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth);
                    cmd.Parameters.AddWithValue("@MobileNo", user.MobileNo);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@FathersName", user.FathersName);
                    cmd.Parameters.AddWithValue("@MothersName", user.MothersName);
                    cmd.Parameters.AddWithValue("@Gender", user.Gender);
                    cmd.Parameters.AddWithValue("@Name", user.Name);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Log the error (for example, using a logging framework)
                throw new Exception("An error occurred while adding the user: " + ex.Message);
            }
        }


        // Method to validate user credentials during login
        public bool ValidateUser(string email, string password)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT COUNT(*) FROM UserDetails WHERE Email = @Email AND Password = @Password";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);

                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();

                    // If the count is greater than 0, the user credentials are valid
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                // Log the error (for example, using a logging framework)
                throw new Exception("An error occurred while validating the user: " + ex.Message);
            }
        }

        // Method to fetch user details by email
        public UserDetails GetUserByEmail(string email)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM UserDetails WHERE Email = @Email";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Email", email);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return new UserDetails
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            programme = reader["programme"].ToString(),
                            NeetRollNo = reader["NeetRollNo"].ToString(),
                            DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                            MobileNo = reader["MobileNo"].ToString(),
                            Email = reader["Email"].ToString(),
                            FathersName = reader["FathersName"].ToString(),
                            MothersName = reader["MothersName"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                        
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the error (for example, using a logging framework)
                throw new Exception("An error occurred while fetching user details: " + ex.Message);
            }

            // Return null if no user found
            return null;
        }





        public List<Category> GetCategoryValues()
        {
            var Category = new List<Category>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Define the SQL query to fetch dropdown values
                    SqlCommand command = new SqlCommand("SELECT Id, Category_name FROM Category", connection);

                    // Open the database connection
                    connection.Open();

                    // Execute the query and read the results
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Add each record to the programmes list
                            Category.Add(new Category
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Category_name = reader["Category_name"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception (you can replace this with your logging mechanism)
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return Category;
        }









        public List<Subcategory> GetSubcategoryValues()
        {
            var subcategories = new List<Subcategory>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT Id, Subcategory_name FROM Subcategory";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                subcategories.Add(new Subcategory
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                    Subcategory_name = reader.GetString(reader.GetOrdinal("Subcategory_name"))
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Database error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            return subcategories;
        }







        public List<CollegeName> GetCollegeNameValues()
        {
            var collegeNames = new List<CollegeName>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT Id, College_Name FROM CollegeName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                collegeNames.Add(new CollegeName
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                    College_Name = reader.GetString(reader.GetOrdinal("College_Name"))
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Database error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            return collegeNames;
        }













        public void SubmitRegistrationForm(Registration registration, byte[] photoBytes)
        {
            string procedureName = "GetRegistrationForm"; // The stored procedure name

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(procedureName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Map Registration model to stored procedure parameters
                    cmd.Parameters.AddWithValue("@Domicile", registration.Domicile);
                    cmd.Parameters.AddWithValue("@Category", registration.Category);
                    cmd.Parameters.AddWithValue("@CertNo1", registration.CertNo1);
                    cmd.Parameters.AddWithValue("@IssueDate1", registration.IssueDate1);
                    cmd.Parameters.AddWithValue("@SubCategory", registration.SubCategory);
                    cmd.Parameters.AddWithValue("@CertNo2", registration.CertNo2);
                    cmd.Parameters.AddWithValue("@InternCert", registration.InternCert);
                    cmd.Parameters.AddWithValue("@CompletionDate", registration.CompletionDate);
                    cmd.Parameters.AddWithValue("@Issuer", registration.Issuer);
                    cmd.Parameters.AddWithValue("@Council", registration.Council);
                    cmd.Parameters.AddWithValue("@RegNo", registration.RegNo);
                    cmd.Parameters.AddWithValue("@Bonded", registration.Bonded);

                    // Convert NOCPath file data to byte[] if a file is uploaded

                    // Handle the case where base64String is null or empty
                    cmd.Parameters.Add("@NOCFilePath", SqlDbType.VarBinary).Value = photoBytes != null ? (object)photoBytes : DBNull.Value;




                    // cmd.Parameters.AddWithValue("@NOCPath", nocFileData); // Pass the binary data to the stored procedure
                    cmd.Parameters.AddWithValue("@NOCIssueDate", registration.NOCIssueDate);
                    cmd.Parameters.AddWithValue("@RemoteBenefit", registration.RemoteBenefit);
                    cmd.Parameters.AddWithValue("@Years", registration.Years);
                    cmd.Parameters.AddWithValue("@MBBSState", registration.MBBSState);
                    cmd.Parameters.AddWithValue("@College", registration.College);
                    cmd.Parameters.AddWithValue("@QuotaSeats", registration.QuotaSeats);
                    cmd.Parameters.AddWithValue("@EligiblePrivateOnly", registration.EligiblePrivateOnly);
                    cmd.Parameters.AddWithValue("@IssueDate2", registration.IssueDate2);
                    cmd.Parameters.AddWithValue("@PMHSCandidate", registration.PMHSCandidate);

                    // Open the connection and execute the stored procedure
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery(); // Execute the stored procedure
                    }
                    catch (Exception ex)
                    {
                        // Log the exception
                        Console.WriteLine("Error: " + ex.Message);
                        // Optionally, log the error for better tracking
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

    }
}
