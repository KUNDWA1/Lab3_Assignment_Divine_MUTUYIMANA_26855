namespace Lab3Assignment.Models
{
    public class Vendor
    {
        public int VendorId { get; set; }
        public string Name { get; set; }
        public string ServiceType { get; set; }
        public decimal PriceMin { get; set; }
        public decimal PriceMax { get; set; }
        public string Location { get; set; }
        public string OwnerEmail { get; set; }
    }
}