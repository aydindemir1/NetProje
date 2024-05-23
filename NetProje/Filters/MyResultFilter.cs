using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using NetProje.Service.SharedDTOs;
using NetProje.Service.Brands.DTOs;

namespace NetProje.API.Filters
{
    public class MyResultFilter : Attribute, IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            var responseBody = (context.Result as ObjectResult).Value;

            if (responseBody is ResponseModelDto<BrandDto> response)
            {
                
            }


            Console.WriteLine("OnResultExecuting");
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine("OnResultExecuted");
        }
    }
}
