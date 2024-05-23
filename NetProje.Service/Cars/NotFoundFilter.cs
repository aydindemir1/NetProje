using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using NetProje.Repository.Cars;
using NetProje.Service.Cars.DTOs;
using NetProje.Service.SharedDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetProje.Service.Cars
{
    public class NotFoundFilter(ICarRepository CarRepository) : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var actionName = ((ControllerBase)context.Controller).ControllerContext.ActionDescriptor.ActionName;


            var CarIdFromAction = context.ActionArguments.Values.First()!;
            int CarId = 0;


            if (CarId == 0 && !int.TryParse(CarIdFromAction.ToString(), out CarId))
            {
                return;
            }

            var hasCar = CarRepository.HasExist(CarId).Result;

            if (!hasCar)
            {
                var errorMessage = $"There is no Car with id: {CarId}";

                var responseModel = ResponseModelDto<NoContent>.Fail(errorMessage);
                context.Result = new NotFoundObjectResult(responseModel);
            }


        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
