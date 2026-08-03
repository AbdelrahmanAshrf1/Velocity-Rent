using DTO.Address;

namespace DTO.Person
{
    public class UpdatePersonRequest
    {
        public UpdatePersonDto personDto {  get; set; }
        public UpdateAddressDto addressDto { get; set; }
    }
}
