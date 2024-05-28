using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetProje.API.Filters;
using NetProje.Controllers;
using NetProje.Service.Models;
using NetProje.Service.Models.AsyncMethods;
using NetProje.Service.Models.DTOs;
using NetProje.Service.Models.ModelCreateUseCase;

namespace NetProje.API.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : CustomBaseController
    {


        private readonly IModelService _ModelService;

        public ModelsController(IModelService ModelService)
        {
            _ModelService = ModelService;
        }



        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _ModelService.GetAll());
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [MyResourceFilter]
        [MyActionFilter]
        [MyResultFilter]
        [HttpGet("{ModelId:int}")]
        public async Task<IActionResult> GetById(int ModelId)
        {
            return CreateActionResult(await _ModelService.GetById(ModelId));
        }


        [HttpGet("page/{page:int}/pagesize/{pageSize:max(50)}")]
        public async Task<IActionResult> GetAllByPage(int page, int pageSize)
        {
            return CreateActionResult(
                await _ModelService.GetAllByPage(page, pageSize));
        }




        [SendSmsWhenExceptionFilter]
        [HttpPost]
        public async Task<IActionResult> Create(ModelCreateRequestDto request)
        {

            var result = await _ModelService.Create(request);

            return CreateActionResult(result, nameof(GetById), new { ModelId = result.Data });
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpPut("UpdateModelName")]
        public async Task<IActionResult> UpdateModelName(ModelNameUpdateRequestDto request)
        {
            return CreateActionResult(await _ModelService.UpdateModelName(request.Id, request.Name));
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpPut("{ModelId:int}")]
        public async Task<IActionResult> Update(int ModelId, ModelUpdateRequestDto request)
        {
            return CreateActionResult(await _ModelService.Update(ModelId, request));
        }





        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpDelete("{ModelId:int}")]
        public async Task<IActionResult> Delete(int ModelId)
        {
            return CreateActionResult(await _ModelService.Delete(ModelId));
        }
    }
}
