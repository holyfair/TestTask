using AutoMapper;
using Repository.Models.Customer;
using TestTask.Enums;
using TestTask.Models.Customer;

namespace TestTask.Mapper.Converters
{
    public class CustomerTypeConverter : ITypeConverter<CustomerBase, CustomerModel>
    {
        public CustomerModel Convert(CustomerBase source, CustomerModel destination, ResolutionContext context)
        {
            switch (source.BrandType)
            {
                case BrandType.MrGreen:
                    return context.Mapper.Map<MrGreenCustomerModel>(source);

                case BrandType.RedBet:
                    return context.Mapper.Map<RedBetCustomerModel>(source);
            }

            return null;
        }
    }
}
