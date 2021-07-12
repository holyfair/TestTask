using AutoMapper;
using Repository.Models.Customer;
using TestTask.Mapper.Converters;
using TestTask.Models.Customer;

namespace TestTask.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MrGreenCustomer, MrGreenCustomerModel>().ReverseMap();

            CreateMap<RedBetCustomer, RedBetCustomerModel>().ReverseMap();

            CreateMap<Address, AddressModel>().ReverseMap();

            CreateMap<CustomerBase, CustomerModel>()
                .ConvertUsing(new CustomerTypeConverter());
        }
    }
}
