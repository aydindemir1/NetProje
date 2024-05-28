using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetProje.API.Filters;
using NetProje.Controllers;
using NetProje.Service.Brands;
using NetProje.Service.Brands.AsyncMethods;
using NetProje.Service.Brands.BrandCreateUseCase;
using NetProje.Service.Brands.DTOs;

namespace NetProje.API.Brands
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : CustomBaseController
    {


        private readonly IBrandService _BrandService;

        public BrandsController(IBrandService BrandService)
        {
            _BrandService = BrandService;
        }



        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _BrandService.GetAll());
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [MyResourceFilter]
        [MyActionFilter]
        [MyResultFilter]
        [HttpGet("{BrandId:int}")]
        public async Task<IActionResult> GetById(int BrandId)
        {
            return CreateActionResult(await _BrandService.GetById(BrandId));
        }


        [HttpGet("page/{page:int}/pagesize/{pageSize:max(50)}")]
        public async Task<IActionResult> GetAllByPage(int page, int pageSize)
        {
            return CreateActionResult(
                await _BrandService.GetAllByPage(page, pageSize));
        }




        [SendSmsWhenExceptionFilter]
        [HttpPost]
        public async Task<IActionResult> Create(BrandCreateRequestDto request)
        {

            var result = await _BrandService.Create(request);

            return CreateActionResult(result, nameof(GetById), new { BrandId = result.Data });
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpPut("UpdateBrandName")]
        public async Task<IActionResult> UpdateBrandName(BrandNameUpdateRequestDto request)
        {
            return CreateActionResult(await _BrandService.UpdateBrandName(request.Id, request.Name));
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpPut("{BrandId:int}")]
        public async Task<IActionResult> Update(int BrandId, BrandUpdateRequestDto request)
        {
            return CreateActionResult(await _BrandService.Update(BrandId, request));
        }





        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpDelete("{BrandId:int}")]
        public async Task<IActionResult> Delete(int BrandId)
        {
            return CreateActionResult(await _BrandService.Delete(BrandId));
        }
    }
}
