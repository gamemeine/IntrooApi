using AutoMapper.Configuration.Annotations;

namespace IntrooApi.Models
{
    public class Event
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string? Title { get; set; }
        public string? Description { get; set; }

        public int RepairId { get; set; }
        public Repair? Repair { get; set; }

        public ICollection<StoreFile>? Photos { get; set; } = new List<StoreFile>();
    }

    public class EventPostDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }

        public int RepairId { get; set; }
        public ICollection<int>? PhotosIds { get; set; }
    }

    public class EventPutDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        public int RepairId { get; set; }
        public ICollection<int>? PhotosIds { get; set; }
    }

    public class EventGeneralInfoDto
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Title { get; set; }
    }

    public class EventDetailsDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public RepairGeneralInfoDto? Repair { get; set; }
        public ICollection<StoreFileDetailsDto>? Photos { get; set; }
    }
}