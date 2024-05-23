using Microsoft.AspNetCore.Mvc;
using NetProje.API.Filters;
using NetProje.Controllers;
using NetProje.Service.Fuels.AsyncMethods;
using NetProje.Service.Fuels.FuelCreateUseCase;
using NetProje.Service.Fuels.DTOs;
using NetProje.Service.Fuels;

namespace NetProje.API.Fuels
{
    public class FuelsController : CustomBaseController
    {


        private readonly IFuelService _FuelService;

        public FuelsController(IFuelService FuelService)
        {
            _FuelService = FuelService;
        }



        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _FuelService.GetAll());
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [MyResourceFilter]
        [MyActionFilter]
        [MyResultFilter]
        [HttpGet("{FuelId:int}")]
        public async Task<IActionResult> GetById(int FuelId)
        {
            return CreateActionResult(await _FuelService.GetById(FuelId));
        }


        [HttpGet("page/{page:int}/pagesize/{pageSize:max(50)}")]
        public async Task<IActionResult> GetAllByPage(int page, int pageSize)
        {
            return CreateActionResult(
                await _FuelService.GetAllByPage(page, pageSize));
        }




        [SendSmsWhenExceptionFilter]
        [HttpPost]
        public async Task<IActionResult> Create(FuelCreateRequestDto request)
        {

            var result = await _FuelService.Create(request);

            return CreateActionResult(result, nameof(GetById), new { FuelId = result.Data });
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpPut("UpdateFuelName")]
        public async Task<IActionResult> UpdateFuelName(FuelNameUpdateRequestDto request)
        {
            return CreateActionResult(await _FuelService.UpdateFuelName(request.Id, request.Name));
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpPut("{FuelId:int}")]
        public async Task<IActionResult> Update(int FuelId, FuelUpdateRequestDto request)
        {
            return CreateActionResult(await _FuelService.Update(FuelId, request));
        }





        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpDelete("{FuelId:int}")]
        public async Task<IActionResult> Delete(int FuelId)
        {
            return CreateActionResult(await _FuelService.Delete(FuelId));
        }
    }
}
