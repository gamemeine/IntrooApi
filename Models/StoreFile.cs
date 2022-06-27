namespace IntrooApi.Models
{
    public class StoreFile
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Name { get; set; }
        public string Extension { get; set; }
        public string? Type { get; set; }
        public string StoreDirectory { get; set; }
        public string AbsoluteDirectory { get; set; }
        public string Source => $"/resource/{Id}";

        public ICollection<Event>? Events { get; set; }
    }

    public class StoreFileDetailsDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public string? Type { get; set; }
        public string Source => $"/resource/{Name}";
    }
}