using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Lab3Assignment.Controllers
{
    public class DatabaseController
    {
        private string connString = "Server=localhost;Port=3306;Database=EventConnectDB;Uid=root;Pwd=;";

        public bool RegisterUser(string name, string email, string phone, string password, string role)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    string query = "INSERT INTO Users (FullName, Email, Phone, Password, Role) VALUES (@n, @e, @p, @pw, @r)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@n", name);
                    cmd.Parameters.AddWithValue("@e", email);
                    cmd.Parameters.AddWithValue("@p", phone);
                    cmd.Parameters.AddWithValue("@pw", password);
                    cmd.Parameters.AddWithValue("@r", role);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch { return false; }
        }

        public string? LoginUser(string email, string password)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                string query = "SELECT Role FROM Users WHERE Email=@e AND Password=@p";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@e", email);
                cmd.Parameters.AddWithValue("@p", password);
                conn.Open();
                object result = cmd.ExecuteScalar();
                return result != null ? result.ToString() : null;
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

        // Gets a single vendor's profile to show on the dashboard
        public DataTable GetVendorProfile(int vendorId)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                string query = "SELECT * FROM Vendors WHERE VendorId = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", vendorId);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        // Updates existing vendor profile
        public void UpdateVendor(int id, string name, string service, decimal price, string location)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                string query = "UPDATE Vendors SET Name=@n, ServiceType=@s, Price=@p, Location=@l WHERE VendorId=@id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@n", name);
                cmd.Parameters.AddWithValue("@s", service);
                cmd.Parameters.AddWithValue("@p", price);
                cmd.Parameters.AddWithValue("@l", location);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
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

        public DataTable GetEvents()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                string query = "SELECT * FROM Events";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                da.Fill(dt);
            }
            return dt;
        }

        public void AddGuest(int eventId, string name, string email, string category)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                string query = "INSERT INTO Guests (EventId, FullNames, Email, Category) VALUES (@e, @n, @em, @c)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@e", eventId);
                cmd.Parameters.AddWithValue("@n", name);
                cmd.Parameters.AddWithValue("@em", email);
                cmd.Parameters.AddWithValue("@c", category);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // --- BOOKING METHODS ---

        // Updated to include the message (phone number / notes)
        public void CreateBooking(int vendorId, int eventId, string message)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                string query = "INSERT INTO Bookings (VendorId, EventId, PriceOffered, Status, Message) VALUES (@v, @e, 1000, 'Pending', @msg)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@v", vendorId);
                cmd.Parameters.AddWithValue("@e", eventId);
                cmd.Parameters.AddWithValue("@msg", message);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetVendorBookings(int vendorId)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                string query = @"SELECT b.BookingId, e.Title as EventTitle, b.Message, b.Status 
                                 FROM Bookings b 
                                 JOIN Events e ON b.EventId = e.EventId 
                                 WHERE b.VendorId = @v";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@v", vendorId);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable GetPlannerBookings()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                string query = @"SELECT b.BookingId, e.Title as EventTitle, v.Name as VendorName, b.Status 
                                 FROM Bookings b 
                                 JOIN Events e ON b.EventId = e.EventId 
                                 JOIN Vendors v ON b.VendorId = v.VendorId";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                da.Fill(dt);
            }
            return dt;
        }

        public void UpdateBookingStatus(int bookingId, string status)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                string query = "UPDATE Bookings SET Status = @s WHERE BookingId = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@s", status);
                cmd.Parameters.AddWithValue("@id", bookingId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}