using Microsoft.EntityFrameworkCore;

namespace IntrooApi.Models
{
    public class Repair
    {
        public Repair()
        {
            CreatedAt = DateTime.Now;
            Status = RepairStatus.Started;
        }

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public RepairStatus Status { get; set; }

        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public int CarId { get; set; }
        public Car? Car { get; set; }

        public IList<Event>? Events { get; set; }
    }

    public enum RepairStatus
    {
        Started = 1, Ended = 0
    }

    public class RepairGeneralInfoDto
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public RepairStatus Status { get; set; }
        public CustomerGeneralInfoDto? Customer { get; set; }
        public CarGeneralInfoDto? Car { get; set; }
    }

    public class RepairDetailsDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public RepairStatus Status { get; set; }
        public CustomerGeneralInfoDto? Customer { get; set; }
        public CarGeneralInfoDto? Car { get; set; }
        public IList<EventGeneralInfoDto>? Events { get; set; }
    }
}