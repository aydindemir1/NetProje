using FluentValidation;
using NetProje.Repository.Models;
using NetProje.Service.Models.ModelCreateUseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetProje.Service.Models.ModelCreateUseCase
{
    public class ModelCreateRequestValidator : AbstractValidator<ModelCreateRequestDto>
    {
        public ModelCreateRequestValidator(IModelRepository ModelRepository)
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} is required")
                .Length(2, 50).WithMessage("{PropertyName} must be between 3 and 50 characters");

            RuleFor(x => x.BrandId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} is required");

            RuleFor(x => x.FuelId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} is required");

            RuleFor(x => x.TransmissionId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} is required");

            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} is required")
                .Length(3, 20).WithMessage("{PropertyName} must be between 3 and 20 characters");
        }


        
    }
}
