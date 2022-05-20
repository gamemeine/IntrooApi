using AutoMapper;
using IntrooApi.Models;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer, CustomerGeneralInfoDto>();
        CreateMap<Customer, CustomerDetailsDto>();
    }
}