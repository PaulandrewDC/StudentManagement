namespace StudentManagement.Models
{
    public class AddStudents
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string? Phone { get; set; }
        public required string Course { get; set; }
    }
}
