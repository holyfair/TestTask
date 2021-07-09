using AutoMapper;
using Repository.DatabaseModels;
using TestTask.Models;
using TestTask.Models.Requests;

namespace TestTask.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateMrGreenBrandRequest, MrGreenBrand>()
                .IncludeBase<CreateBrandBaseRequest, Brand>();

            CreateMap<CreateRedBetBrandRequest, MrGreenBrand>()
                .IncludeBase<CreateBrandBaseRequest, Brand>();

            CreateMap<CreateBrandBaseRequest, Brand>()
                .ForMember(x => x.Street, opt => opt.MapFrom(y => y.Address.Street))
                .ForMember(x => x.House, opt => opt.MapFrom(y => y.Address.House))
                .ForMember(x => x.ZipCode, opt => opt.MapFrom(y => y.Address.ZipCode));
        }
    }
}
