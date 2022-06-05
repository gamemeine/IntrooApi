namespace IntrooApi.Models
{
    public class Car
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
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