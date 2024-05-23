using FluentValidation;
using NetProje.Repository.Brands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetProje.Service.Brands.BrandCreateUseCase
{
    public class BrandCreateRequestValidator : AbstractValidator<BrandCreateRequestDto>
    {
        public BrandCreateRequestValidator(IBrandRepository BrandRepository)
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} is required")
                .Length(3, 10).WithMessage("{PropertyName} must be between 3 and 10 characters");
          


          
        }
    }
}
