using FluentValidation;
using NetProje.Repository.Cars;
using NetProje.Service.Cars.CarCreateUseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetProje.Service.Cars.CarCreateUseCase
{
    public class CarCreateRequestValidator : AbstractValidator<CarCreateRequestDto>
    {
        public CarCreateRequestValidator(ICarRepository CarRepository)
        {
            RuleFor(x => x.ModelId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} is required");

            RuleFor(x => x.Kilometer)
             .NotEmpty().WithMessage("{PropertyName} is required")
             .NotNull().WithMessage("{PropertyName} is required");

            RuleFor(x => x.ModelYear)
              .NotEmpty().WithMessage("{PropertyName} is required")
              .NotNull().WithMessage("{PropertyName} is required");

            RuleFor(x => x.Plate)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} is required")
                .Length(6, 15).WithMessage("{PropertyName} must be between 6 and 15 characters");
            
          




        }
    }
}
