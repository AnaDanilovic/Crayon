using AutoMapper;
using CloudSales.Model.Dto;
using CloudSales.Model.Model;

namespace CloudSales.WebAPI.Helpers
{
    public class PurchasedSoftwareProfile : Profile
    {
        public PurchasedSoftwareProfile()
        {
            CreateMap<PurchasedSoftware, PurchasedSoftwareDto>()
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => MapStringToState(src.State)));

            CreateMap<PurchasedSoftwareDto, PurchasedSoftware>()
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => MapStateToString(src.State)));
        }

        private string MapStateToString(bool state)
        {
            return state ? "Active" : "Inactive";
        }

        private bool MapStringToState(string state)
        {
            return state.Equals("Active", StringComparison.OrdinalIgnoreCase);
        }
    }
}
