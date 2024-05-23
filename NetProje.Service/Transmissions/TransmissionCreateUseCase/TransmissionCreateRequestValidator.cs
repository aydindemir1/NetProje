using FluentValidation;
using NetProje.Repository.Transmissions;
using NetProje.Service.Transmissions.TransmissionCreateUseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetProje.Service.Transmissions.TransmissionCreateUseCase
{
    public class TransmissionCreateRequestValidator : AbstractValidator<TransmissionCreateRequestDto>
    {
        public TransmissionCreateRequestValidator(ITransmissionRepository TransmissionRepository)
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} is required")
                .Length(3, 15).WithMessage("{PropertyName} must be between 3 and 15 characters");




        }
    }
}
