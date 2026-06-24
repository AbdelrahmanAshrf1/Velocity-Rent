using DTO;
using FluentValidation;

namespace VelocityRent.Validators.Validators.User
{
    public class AddUserDtoValidator : AbstractValidator<AddUserDto>
    {
        public AddUserDtoValidator()
        {
            RuleFor(x => x.PersonID).GreaterThan(0);
            RuleFor(x => x.Username).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.Password).NotEmpty().MinimumLength(8);
            RuleFor(x => x.UserRole).IsInEnum();
        }
    }
}
