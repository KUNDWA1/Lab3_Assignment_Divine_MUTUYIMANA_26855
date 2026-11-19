using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Lab3Assignment.Controllers
{
    public class DatabaseController
    {
        private readonly string connString =
            "Server=localhost;Port=3306;Database=EventConnectDB;Uid=root;Pwd=;";

       
        // USERS
        

        // Returns the user's Role ("Vendor" / "Event Planner"), or null if the credentials are wrong.
        public string LoginUser(string email, string password)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                string query = "SELECT Role FROM Users WHERE Email=@e AND Password=@p LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@e", email);
                cmd.Parameters.AddWithValue("@p", password);
                conn.Open();
                object result = cmd.ExecuteScalar();
                return (result == null || result == DBNull.Value) ? null : result.ToString();
            }
        }

        // Returns false if the account could not be created (e.g. the email already exists).
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
            catch (MySqlException)
            {
                return false;
            }
        }

    
        // VENDORS
        

        // Planner's vendor list. PriceRange is a ready-to-show string like "50,000 - 100,000 RWF".
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
                                 FROM Vendors
                                 ORDER BY Name";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                da.Fill(dt);
            }
            return dt;
        }

        // The profile that belongs to the logged-in vendor (empty table = no profile yet).
        public DataTable GetVendorByEmail(string email)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                string query = @"SELECT VendorId, Name, ServiceType, PriceMin, PriceMax, Location
                                 FROM Vendors WHERE OwnerEmail = @e LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@e", email);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        // Creates the vendor's profile and returns the new VendorId
        
        public int CreateVendorProfile(string email, string name, string service, decimal priceMin, decimal priceMax, string location)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                string query = @"INSERT INTO Vendors (OwnerEmail, Name, ServiceType, PriceMin, PriceMax, Location)
                                 VALUES (@o, @n, @s, @min, @max, @l)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@o", email);
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

        public void UpdateVendor(int vendorId, string name, string service, decimal priceMin, decimal priceMax, string location)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                string query = @"UPDATE Vendors
                                 SET Name=@n, ServiceType=@s, PriceMin=@min, PriceMax=@max, Location=@l
                                 WHERE VendorId=@id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@n", name);
                cmd.Parameters.AddWithValue("@s", service);
                cmd.Parameters.AddWithValue("@min", priceMin);
                cmd.Parameters.AddWithValue("@max", priceMax);
                cmd.Parameters.AddWithValue("@l", location);
                cmd.Parameters.AddWithValue("@id", vendorId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        
        // EVENTS & GUESTS
        

        public DataTable GetEvents()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                string query = "SELECT EventId, Title, EventDate, Budget FROM Events ORDER BY EventDate";
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

        // Not called by the current Views, but the Guests table exists, so it is ready for use.
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

        
        // BOOKINGS
        

        // PriceOffered is taken from the event's budget; status starts as 'Pending'.
        public void CreateBooking(int vendorId, int eventId, string message)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                string query = @"INSERT INTO Bookings (VendorId, EventId, PriceOffered, Status, Message)
                                 VALUES (@v, @e, COALESCE((SELECT Budget FROM Events WHERE EventId = @e), 0), 'Pending', @msg)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@v", vendorId);
                cmd.Parameters.AddWithValue("@e", eventId);
                cmd.Parameters.AddWithValue("@msg", message);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Planner's bookings (Events + Vendors), including the vendor's reply.
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

        // Vendor's incoming requests (joins Events).
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

        // Vendor accepts/rejects ("Accepted" / "Rejected") and leaves a note for the planner.
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
    }
}
