using FluentValidation;
using NetProje.Repository.Fuels;
using NetProje.Service.Fuels.FuelCreateUseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetProje.Service.Fuels.FuelCreateUseCase
{
    public class FuelCreateRequestValidator : AbstractValidator<FuelCreateRequestDto>
    {
        public FuelCreateRequestValidator(IFuelRepository FuelRepository)
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} is required")
                .Length(3, 15).WithMessage("{PropertyName} must be between 3 and 15 characters");




        }
    }
}
