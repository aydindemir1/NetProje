using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using NetProje.Repository.Fuels;
using NetProje.Service.Fuels.DTOs;
using NetProje.Service.SharedDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetProje.Service.Fuels
{
    public class NotFoundFilter(IFuelRepository FuelRepository) : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var actionName = ((ControllerBase)context.Controller).ControllerContext.ActionDescriptor.ActionName;


            var FuelIdFromAction = context.ActionArguments.Values.First()!;
            int FuelId = 0;

            if (actionName == "UpdateFuelName" &&
                FuelIdFromAction is FuelNameUpdateRequestDto FuelNameUpdateRequestDto)
            {
                FuelId = FuelNameUpdateRequestDto.Id;
            }


            if (FuelId == 0 && !int.TryParse(FuelIdFromAction.ToString(), out FuelId))
            {
                return;
            }

            var hasFuel = FuelRepository.HasExist(FuelId).Result;

            if (!hasFuel)
            {
                var errorMessage = $"There is no Fuel with id: {FuelId}";

                var responseModel = ResponseModelDto<NoContent>.Fail(errorMessage);
                context.Result = new NotFoundObjectResult(responseModel);
            }


        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
