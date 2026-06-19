
using DTO.Address;
using FluentValidation;

namespace VelocityRent.Validators.Validators.Address
{
    public abstract class BaseAddressDtoValidator<T> :AbstractValidator<T>
        where T : BaseAddressDto
    {
        protected BaseAddressDtoValidator()
        {
            RuleFor(x => x.City).NotEmpty().MaximumLength(50);
            RuleFor(x => x.State).NotEmpty().MaximumLength(50);
            RuleFor(x => x.ZipCode).NotEmpty().MaximumLength(15);
            RuleFor(x => x.Country).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Latitude).InclusiveBetween(-90, 90);
            RuleFor(x => x.Longitude).InclusiveBetween(-180, 180);
        }
    }
}
