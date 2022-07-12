namespace ems.Server.model
{
    public class EmployeeModel
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public decimal Salary { get; set; } = 0;
        public int Role { get; set; } = 0;
        public int Status { get; set; } = 1;
        public string? ProfileImage { get; set; }
    }
}
