using DTO.Address;
using FluentValidation;

namespace VelocityRent.Validators.Validators.Address
{
    public class AddAddressDtoValidator :AbstractValidator<AddAddressDto>
    {
        protected AddAddressDtoValidator()
        {
            RuleFor(x => x.City).NotEmpty().MaximumLength(100);
            RuleFor(x => x.State).NotEmpty().MaximumLength(100);
            RuleFor(x => x.ZipCode).NotEmpty().MaximumLength(20);
            RuleFor(x => x.Country).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Latitude).InclusiveBetween(-90, 90);
            RuleFor(x => x.Longitude).InclusiveBetween(-180, 180);
        }
    }
}
