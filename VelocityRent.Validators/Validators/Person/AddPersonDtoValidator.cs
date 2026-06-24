using DTO;
using FluentValidation;
using System;


namespace VelocityRent.Validators.Validators.Person
{
    public class AddPersonDtoValidator : AbstractValidator<AddPersonDto>
    {
        public AddPersonDtoValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);

            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Phone).NotEmpty().Matches(@"^\+?\d{7,15}$");

            RuleFor(x => x.DateOfBirth).NotEmpty().LessThan(DateTime.Today);

            RuleFor(x => x.NationalID).NotEmpty().Matches(@"^\d{14}$");
        }
    }
}
