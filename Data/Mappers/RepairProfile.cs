using AutoMapper;
using IntrooApi.Models;

public class RepairProfile : Profile
{
    public RepairProfile()
    {
        CreateMap<Repair, RepairDetailsDto>();
        CreateMap<Repair, RepairGeneralInfoDto>();
        CreateMap<Car, CarGeneralInfoDto>();
        CreateMap<Event, EventGeneralInfoDto>();
    }
}