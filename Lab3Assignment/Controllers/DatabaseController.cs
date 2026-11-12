using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace EventConnect.Controllers
{
    public class DatabaseController
    {
        // Connection string for XAMPP MySQL (user root, empty password)
        private string connString = "Server=localhost;Port=3306;Database=EventConnectDB;Uid=root;Pwd=;";

        public void AddVendor(string name, string service, decimal price, string location)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                string query = "INSERT INTO Vendors (Name, ServiceType, Price, Location) VALUES (@n, @s, @p, @l)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@n", name);
                cmd.Parameters.AddWithValue("@s", service);
                cmd.Parameters.AddWithValue("@p", price);
                cmd.Parameters.AddWithValue("@l", location);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetVendors()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                string query = "SELECT * FROM Vendors";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                da.Fill(dt);
            }
            return dt;
        }

        public void AddEvent(string title, DateTime date, decimal budget)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                string query = "INSERT INTO Events (Title, EventDate, Budget) VALUES (@t, @d, @b)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@t", title);
                cmd.Parameters.AddWithValue("@d", date);
                cmd.Parameters.AddWithValue("@b", budget);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
