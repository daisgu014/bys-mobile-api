using AutoMapper;
using BYS.Mobile.API.Data.Models;
using BYS.Mobile.API.Shared.Response;

namespace BYS.Mobile.API.Data.Profiles;

public class IcProductProfile : Profile
{
    public IcProductProfile()
    {
        CreateMap<Icproduct, ProductResponse>()
            .ForMember(dest => dest.ItemNo, opt => opt.MapFrom(src => src.IcproductNoOfOldSys))
            .ForMember(dest => dest.ItemName, opt => opt.MapFrom(src => src.IcproductName))
            .ForMember(dest => dest.Picture, opt => opt.MapFrom(src => src.IcproductImageFile))
            .ForMember(dest => dest.Packing, opt => opt.MapFrom(src => src.IcproductPackagingDetail))
            .ForMember(dest => dest.QuantityPer20Ft, opt => opt.MapFrom(src => src.IcproductQtyInBox))
            .ForMember(dest => dest.ItemWeightKgs, opt => opt.MapFrom(src => src.IcproductGrossWeight))
            .ForMember(dest => dest.Wood,
                opt => opt.MapFrom(src => src.FkIcproductAttributeWoodType.IcproductAttributeValue));
    }
    
}