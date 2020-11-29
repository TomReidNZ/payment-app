using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using System.Linq;
using System.Threading.Tasks;

namespace CoursesWebApp.Models
{
    public class DataAccessController
    {
        // Add your connection string in the following statements
        string connectionString = "Server=payment-server-demo.postgres.database.azure.com;Database=paymentapp;Port=5432;User Id=paymentadmin@payment-server-demo;Password=Paymentapp69;Ssl Mode=Require;";

        // Retrieve all details of courses and their modules    
        public IEnumerable<Users> GetAllUsers()
        {
            List<Users> userList = new List<Users>();

            // Connect to the database
            using (var conn = new NpgsqlConnection(connectionString))

            {
                Console.Out.WriteLine("Opening connection");
                conn.Open();
                using (var command = new NpgsqlCommand("SELECT * FROM users", conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string userID = reader.GetInt32(0).ToString();
                        string userName = reader.GetString(1);
                        int moduleSequence = reader.GetInt32(2);
                        Users user = new Users(userID, userName, moduleSequence);
                        userList.Add(user);
                    }
                }
                conn.Close();
            }
            return userList;
        }
    }
}
