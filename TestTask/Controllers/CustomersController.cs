using System.Threading.Tasks;
using AutoMapper;
using Repository.Repository;
using Repository.Models.Customer;
using TestTask.Models.Customer;
using Microsoft.AspNetCore.Mvc;
using TestTask.Enums;
using Newtonsoft.Json;
using TestTask.Converters;

namespace TestTask.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private IMapper mapper;
        private ICustomersRepository customersRepository;

        public CustomersController(IMapper mapper, ICustomersRepository customersRepository)
        {
            this.mapper = mapper;
            this.customersRepository = customersRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerBase request, BrandType brandType)
        {
            request.BrandType = brandType;
            var model = mapper.Map<CustomerModel>(request);
            var record = await this.customersRepository.CreateAsync(model);

            return Ok(record);
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetAll()
        {
            var records = await this.customersRepository.GetAsync();
            var json = JsonConvert.SerializeObject(records, new PolymorphicJsonConverter());

            return Ok(json);
        }
    }
}
