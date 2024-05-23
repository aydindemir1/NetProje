using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using NetProje.Repository.Models;
using NetProje.Service.Models.DTOs;
using NetProje.Service.SharedDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text;
using System.Threading.Tasks;

namespace NetProje.Service.Models
{
    public class NotFoundFilter(IModelRepository ModelRepository) : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            
            var actionName = ((ControllerBase)context.Controller).ControllerContext.ActionDescriptor.ActionName;


            var ModelIdFromAction = context.ActionArguments.Values.First()!;
            int ModelId = 0;

            if (actionName == "UpdateModelName" &&
                ModelIdFromAction is ModelNameUpdateRequestDto ModelNameUpdateRequestDto)
            {
                ModelId = ModelNameUpdateRequestDto.Id;
            }


            if (ModelId == 0 && !int.TryParse(ModelIdFromAction.ToString(), out ModelId))
            {
                return;
            }

            var hasModel = ModelRepository.HasExist(ModelId).Result;

            if (!hasModel)
            {
                var errorMessage = $"There is no Model with id: {ModelId}";

                var responseModel = ResponseModelDto<NoContent>.Fail(errorMessage);
                context.Result = new NotFoundObjectResult(responseModel);
            }


        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
