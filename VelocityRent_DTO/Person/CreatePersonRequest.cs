using DTO.Address;

namespace DTO.Person
{
    public class CreatePersonRequest
    {
        public AddPersonDto personDto {  get; set; }
        public AddAddressDto AddressDto {  get; set; }
    }
}
