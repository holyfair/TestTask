using System.Threading.Tasks;
using AutoMapper;
using Repository.Repository;
using Repository.Models.Customer;
using TestTask.Models.Customer;
using Microsoft.AspNetCore.Mvc;
using TestTask.Enums;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using AspNetCoreRateLimit;
using Microsoft.Extensions.Options;

namespace TestTask.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private IMapper mapper;
        private ICustomersRepository customersRepository;
        private readonly IpRateLimitOptions _options;
        private readonly IIpPolicyStore _ipPolicyStore;

        public CustomersController(IMapper mapper, ICustomersRepository customersRepository, IOptions<IpRateLimitOptions> optionsAccessor, IIpPolicyStore ipPolicyStore)
        {
            this.mapper = mapper;
            this.customersRepository = customersRepository;
            _options = optionsAccessor.Value;
            _ipPolicyStore = ipPolicyStore;
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
        public async Task<IActionResult> GetAll()
        {
            var records = await this.customersRepository.GetAsync();
            var json = JsonSerializer.Serialize(records);

            return Ok(json);
        }

        //[Route(""), HttpGet]
        //[ApiExplorerSettings(IgnoreApi = true)]
        //public RedirectResult RedirectToSwaggerUi()
        //{
        //    return Redirect("/swagger/");
        //}
    }

}
