namespace IntrooApi.Models
{
    public class Car
    {
        public Car()
        {
            CreatedAt = DateTime.Now;
        }

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Model { get; set; }
        public string? Plate { get; set; }

        public IList<Repair> Repairs { get; } = new List<Repair>();
    }

    public class CarGeneralInfoDto
    {
        public int Id { get; set; }
        public string? Model { get; set; }
        public string? Plate { get; set; }
    }
}