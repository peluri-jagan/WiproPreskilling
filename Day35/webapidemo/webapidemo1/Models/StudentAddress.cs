namespace webapidemo1.Models
{
    public class StudentAddress
    {
        public int StudentAddressId { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int PinCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        // Foreign Key
        public int StudentId { get; set; }

        // Navigation property
        public virtual Student Student { get; set; }
    }
}
