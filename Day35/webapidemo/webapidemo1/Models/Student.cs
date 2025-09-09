namespace webapidemo1.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;

        // Navigation property
        public virtual StudentAddress? Address { get; set; }
    }
}
