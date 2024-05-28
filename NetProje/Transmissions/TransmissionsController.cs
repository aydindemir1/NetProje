using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetProje.API.Filters;
using NetProje.Controllers;
using NetProje.Service.Transmissions;
using NetProje.Service.Transmissions.AsyncMethods;
using NetProje.Service.Transmissions.DTOs;
using NetProje.Service.Transmissions.TransmissionCreateUseCase;

namespace NetProje.API.Transmissions
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransmissionsController : CustomBaseController
    {


        private readonly ITransmissionService _TransmissionService;

        public TransmissionsController(ITransmissionService TransmissionService)
        {
            _TransmissionService = TransmissionService;
        }



        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _TransmissionService.GetAll());
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [MyResourceFilter]
        [MyActionFilter]
        [MyResultFilter]
        [HttpGet("{TransmissionId:int}")]
        public async Task<IActionResult> GetById(int TransmissionId)
        {
            return CreateActionResult(await _TransmissionService.GetById(TransmissionId));
        }


        [HttpGet("page/{page:int}/pagesize/{pageSize:max(50)}")]
        public async Task<IActionResult> GetAllByPage(int page, int pageSize)
        {
            return CreateActionResult(
                await _TransmissionService.GetAllByPage(page, pageSize));
        }




        [SendSmsWhenExceptionFilter]
        [HttpPost]
        public async Task<IActionResult> Create(TransmissionCreateRequestDto request)
        {

            var result = await _TransmissionService.Create(request);

            return CreateActionResult(result, nameof(GetById), new { TransmissionId = result.Data });
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpPut("UpdateTransmissionName")]
        public async Task<IActionResult> UpdateTransmissionName(TransmissionNameUpdateRequestDto request)
        {
            return CreateActionResult(await _TransmissionService.UpdateTransmissionName(request.Id, request.Name));
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpPut("{TransmissionId:int}")]
        public async Task<IActionResult> Update(int TransmissionId, TransmissionUpdateRequestDto request)
        {
            return CreateActionResult(await _TransmissionService.Update(TransmissionId, request));
        }





        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpDelete("{TransmissionId:int}")]
        public async Task<IActionResult> Delete(int TransmissionId)
        {
            return CreateActionResult(await _TransmissionService.Delete(TransmissionId));
        }
    }
}
