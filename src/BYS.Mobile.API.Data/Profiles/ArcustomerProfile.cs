using AutoMapper;
using BYS.Mobile.API.Data.Models;
using BYS.Mobile.API.Shared.Constants;
using BYS.Mobile.API.Shared.Request.Customer;
using BYS.Mobile.API.Shared.Response;

namespace BYS.Mobile.API.Data.Profiles;

public class ArcustomerProfile : Profile
{
    public ArcustomerProfile()
    {
        CreateMap<CustomerRequest, Arcustomer>()
            .ForMember(dest => dest.ArcustomerContactAddressLine1, opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.Aastatus, opt => opt.MapFrom(src=>Status.ALIVE));
        CreateMap<Arcustomer, CustomerResponse>();
    }
}