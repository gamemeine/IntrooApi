using AutoMapper;
using IntrooApi.Models;

public class StoreFileProfile : Profile
{
    public StoreFileProfile()
    {
        CreateMap<StoreFile, StoreFileDetailsDto>();
    }
}