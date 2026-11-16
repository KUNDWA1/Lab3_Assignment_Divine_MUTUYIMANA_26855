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

        // ==========================================
        // VENDORS
        // ==========================================

        // Planner list of vendors. PriceRange is a ready-to-show text like "50,000 - 100,000 RWF".
        public DataTable GetVendors()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                string query = @"SELECT VendorId, Name, ServiceType,
                                        CASE WHEN PriceMin = PriceMax
                                             THEN CONCAT(FORMAT(PriceMin, 0), ' RWF')
                                             ELSE CONCAT(FORMAT(PriceMin, 0), ' - ', FORMAT(PriceMax, 0), ' RWF')
                                        END AS PriceRange,
                                        Location
                                 FROM Vendors";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                da.Fill(dt);
            }
            return dt;
        }

        // Gets a single vendor's profile by ID
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

        // Finds the profile that belongs to the logged-in vendor (empty table = no profile yet)
        public DataTable GetVendorByEmail(string ownerEmail)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                string query = "SELECT VendorId, Name, ServiceType, PriceMin, PriceMax, Location FROM Vendors WHERE OwnerEmail = @e LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@e", ownerEmail);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        // Creates a vendor profile for the logged-in vendor and returns the new VendorId.
        // The old Price column is kept in sync with the minimum price.
        public int CreateVendorProfile(string ownerEmail, string name, string service, decimal priceMin, decimal priceMax, string location)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                string query = @"INSERT INTO Vendors (OwnerEmail, Name, ServiceType, Price, PriceMin, PriceMax, Location)
                                 VALUES (@o, @n, @s, @min, @min, @max, @l)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@o", ownerEmail);
                cmd.Parameters.AddWithValue("@n", name);
                cmd.Parameters.AddWithValue("@s", service);
                cmd.Parameters.AddWithValue("@min", priceMin);
                cmd.Parameters.AddWithValue("@max", priceMax);
                cmd.Parameters.AddWithValue("@l", location);
                conn.Open();
                cmd.ExecuteNonQuery();
                return (int)cmd.LastInsertedId;
            }
        }

        // Updates existing vendor profile
        public void UpdateVendor(int id, string name, string service, decimal priceMin, decimal priceMax, string location)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                string query = @"UPDATE Vendors
                                 SET Name=@n, ServiceType=@s, Price=@min, PriceMin=@min, PriceMax=@max, Location=@l
                                 WHERE VendorId=@id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@n", name);
                cmd.Parameters.AddWithValue("@s", service);
                cmd.Parameters.AddWithValue("@min", priceMin);
                cmd.Parameters.AddWithValue("@max", priceMax);
                cmd.Parameters.AddWithValue("@l", location);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // ==========================================
        // EVENTS & GUESTS
        // ==========================================
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

        // ==========================================
        // BOOKINGS
        // ==========================================

        // PriceOffered now comes from the event's budget instead of a hardcoded 1000
        public void CreateBooking(int vendorId, int eventId, string message)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                string query = @"INSERT INTO Bookings (VendorId, EventId, PriceOffered, Status, Message)
                                 VALUES (@v, @e, (SELECT Budget FROM Events WHERE EventId = @e), 'Pending', @msg)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@v", vendorId);
                cmd.Parameters.AddWithValue("@e", eventId);
                cmd.Parameters.AddWithValue("@msg", message);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Vendor's incoming requests, with the planner's message and the vendor's own reply
        public DataTable GetVendorBookings(int vendorId)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                string query = @"SELECT b.BookingId, e.Title AS EventTitle, e.EventDate, e.Budget,
                                        b.Message, b.Status, b.VendorResponse
                                 FROM Bookings b
                                 JOIN Events e ON b.EventId = e.EventId
                                 WHERE b.VendorId = @v
                                 ORDER BY b.BookingId DESC";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@v", vendorId);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        // Planner's bookings, including what the vendor replied
        public DataTable GetPlannerBookings()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                string query = @"SELECT b.BookingId, e.Title AS EventTitle, v.Name AS VendorName,
                                        b.Status, b.Message, b.VendorResponse
                                 FROM Bookings b
                                 JOIN Events e ON b.EventId = e.EventId
                                 JOIN Vendors v ON b.VendorId = v.VendorId
                                 ORDER BY b.BookingId DESC";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                da.Fill(dt);
            }
            return dt;
        }

        // Vendor accepts or rejects and leaves a note for the planner
        public void RespondToBooking(int bookingId, string status, string response)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                string query = "UPDATE Bookings SET Status = @s, VendorResponse = @r WHERE BookingId = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@s", status);
                cmd.Parameters.AddWithValue("@r", response);
                cmd.Parameters.AddWithValue("@id", bookingId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
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