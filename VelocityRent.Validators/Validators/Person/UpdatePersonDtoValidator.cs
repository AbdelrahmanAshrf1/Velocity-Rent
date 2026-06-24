using DTO.Person;
using FluentValidation;
using System;

namespace VelocityRent.Validators.Validators.Person
{
    public class UpdatePersonDtoValidator : AbstractValidator<UpdatePersonDto>
    {
        public UpdatePersonDtoValidator()
        {
            RuleFor(x => x.ID).GreaterThan(0);
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);

            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Phone).NotEmpty().Matches(@"^\+?\d{7,15}$");

            RuleFor(x => x.DateOfBirth).NotEmpty().LessThan(DateTime.Today);
        }
    }
}
