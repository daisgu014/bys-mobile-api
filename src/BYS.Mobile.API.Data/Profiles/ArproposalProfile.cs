using AutoMapper;
using BYS.Mobile.API.Data.Models;
using BYS.Mobile.API.Shared.Response;

namespace BYS.Mobile.API.Data.Profiles;

public class ArproposalProfile : Profile
{
    public ArproposalProfile()
    {
        CreateMap<Arproposal, ProposalResponse>()
            .ForMember(dest => dest.ProposalNo, opt => opt.MapFrom(src => src.ArproposalNo))
            .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.FkArcustomer.ArcustomerName))
            .ForMember(dest => dest.ContactInfo, opt => opt.MapFrom(src => src.FkArcustomer.ArcustomerContactName))
            .ForMember(dest => dest.ProposalDate, opt => opt.MapFrom(src => src.AacreatedDate))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.FkArcustomer.Aastatus));
    }
}