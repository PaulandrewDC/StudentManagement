namespace StudentManagement.Models
{
    public class UpdateStudent
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string? Phone { get; set; }
        public required string Course { get; set; }
    }
}
