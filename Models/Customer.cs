namespace IntrooApi.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }

        public List<Repair>? Repairs { get; set; }
    }

    public class CustomerGeneralInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class CustomerDetailsDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? PhoneNumber { get; set; }
        public List<RepairGeneralInfoDto>? Repairs { get; set; }
    }
}