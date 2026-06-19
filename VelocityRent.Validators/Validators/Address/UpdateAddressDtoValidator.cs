using DTO.Address;
using FluentValidation;
using VelocityRent.Validators.Validators.Address;

namespace VelocityRent_DLL.Validators.Address
{
    public class UpdateAddressDtoValidator :BaseAddressDtoValidator<UpdateAddressDto>
    {
        public UpdateAddressDtoValidator()
        {
            RuleFor(x => x.ID).GreaterThan(0).WithMessage("Invalid Address ID.");
        }
    }
}
