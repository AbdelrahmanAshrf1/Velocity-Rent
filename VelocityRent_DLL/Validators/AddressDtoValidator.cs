using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using VelocityRent.Dto;

namespace VelocityRent_DLL.Validators
{
    public class AddressDtoValidator : AbstractValidator<AddressDto>
    {
        public AddressDtoValidator()
        {
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.Country).NotEmpty();
        }
    }
}
