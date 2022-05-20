using IntrooApi.Models;

namespace IntrooApi.Data
{
    public interface IEventRepository
    {
        Task<IEnumerable<EventGeneralInfoDto>> GetAllEvents();
        Task<EventDetailsDto> GetEventById(int id);
        Task AddEvent(Event _event);
        Task DeleteEvent(int id);
        Task UpdateEvent(Event _event);
        Task Save();
    }
}