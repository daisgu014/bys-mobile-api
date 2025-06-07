using AutoMapper;
using BYS.Mobile.API.Data.Models;
using BYS.Mobile.API.Shared.Response;

namespace BYS.Mobile.API.Data.Profiles;

public class ProposalProfile : Profile
{
    public ProposalProfile()
    {
        CreateMap<Arproposal, ArproposalResponse>();
        CreateMap<ArproposalItem, ArproposalItemResponse>();
    }
}