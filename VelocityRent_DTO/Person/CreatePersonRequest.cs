using DTO.Address;

namespace DTO.Person
{
    public class CreatePersonRequest
    {
        public AddPersonDto PersonDto {  get; set; }
        public AddAddressDto AddressDto {  get; set; }
    }
}
