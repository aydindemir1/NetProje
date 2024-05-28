using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetProje.API.Filters;
using NetProje.Controllers;
using NetProje.Service.Cars;
using NetProje.Service.Cars.AsyncMethods;
using NetProje.Service.Cars.CarCreateUseCase;
using NetProje.Service.Cars.DTOs;

namespace NetProje.API.Cars
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : CustomBaseController
    {


        private readonly ICarService _CarService;

        public CarsController(ICarService CarService)
        {
            _CarService = CarService;
        }



        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _CarService.GetAll());
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [MyResourceFilter]
        [MyActionFilter]
        [MyResultFilter]
        [HttpGet("{CarId:int}")]
        public async Task<IActionResult> GetById(int CarId)
        {
            return CreateActionResult(await _CarService.GetById(CarId));
        }


        [HttpGet("page/{page:int}/pagesize/{pageSize:max(50)}")]
        public async Task<IActionResult> GetAllByPage(int page, int pageSize)
        {
            return CreateActionResult(
                await _CarService.GetAllByPage(page, pageSize));
        }




        [SendSmsWhenExceptionFilter]
        [HttpPost]
        public async Task<IActionResult> Create(CarCreateRequestDto request)
        {

            var result = await _CarService.Create(request);

            return CreateActionResult(result, nameof(GetById), new { CarId = result.Data });
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpPut("UpdateCarPlate")]
        public async Task<IActionResult> UpdateCarPlate(int id, string plate)
        {
            return CreateActionResult(await _CarService.UpdateCarPlate(id, plate));
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpPut("{CarId:int}")]
        public async Task<IActionResult> Update(int CarId, CarUpdateRequestDto request)
        {
            return CreateActionResult(await _CarService.Update(CarId, request));
        }





        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpDelete("{CarId:int}")]
        public async Task<IActionResult> Delete(int CarId)
        {
            return CreateActionResult(await _CarService.Delete(CarId));
        }
    }
}
