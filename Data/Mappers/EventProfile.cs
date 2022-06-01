using AutoMapper;
using IntrooApi.Models;

namespace IntrooApi.Data
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Event, EventGeneralInfoDto>();
            CreateMap<Event, EventDetailsDto>();
            CreateMap<EventPostDto, Event>();
            CreateMap<EventPutDto, Event>();
        }
    }
}