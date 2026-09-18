using DTO.Address;

namespace DTO.Person
{
    public class UpdatePersonRequest
    {
        public UpdatePersonDto PersonDto {  get; set; }
        public UpdateAddressDto AddressDto { get; set; }
    }
}
