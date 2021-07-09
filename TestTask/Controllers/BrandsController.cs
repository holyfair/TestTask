using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Enums;
using TestTask.JsonConverters;
using TestTask.Models;
using TestTask.Models.Requests;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using AutoMapper;
using Repository.Interfaces;
using Repository.DatabaseModels;

namespace TestTask.Controllers
{
    [ApiController]
    [Route("api/brands")]
    public class BrandsController : ControllerBase
    {
        private readonly Dictionary<BrandType, Type> mappingTypes = new Dictionary<BrandType, Type>
        {
            { BrandType.MrGreen, typeof(MrGreenBrand) },
            { BrandType.RedBet, typeof(RedBetBrand) }
        };

        private IMapper mapper;
        private IBrandsRepository brandsRepository;

        public BrandsController(IMapper mapper, IBrandsRepository brandsRepository)
        {
            this.mapper = mapper;
            this.brandsRepository = brandsRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandBaseRequest request)
        {
            var model = this.mapper.Map(request, mappingTypes[request.BrandType]);
            //var record = await this.brandsRepository.CreateBrandAsync(model as Brand);
            return Ok(request);
        }


        [HttpGet]
        public async Task<ActionResult> CreateBrand()
        {
            return Ok("Darova");
        }
    }

}
