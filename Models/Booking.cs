namespace Lab3Assignment.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int EventId { get; set; }
        public int VendorId { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public string VendorResponse { get; set; }
    }
}s