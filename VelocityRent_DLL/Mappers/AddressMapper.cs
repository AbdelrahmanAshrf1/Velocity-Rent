using DTO.Address;
using VelocityRent.Entities;

namespace VelocityRent_DLL.Mappers
{
    public static class AddressMapper
    {
        public static Address ToEntity(AddAddressDto dto)
        {
            return new Address(
                city: dto.City,
                state: dto.State,
                zipCode: dto.ZipCode,
                country: dto.Country,
                latitude: dto.Latitude,
                longitude: dto.Longitude
                );
        }

        public static AddressDto ToDto(Address address)
        {
            return new AddressDto
            {
                City = address.City,
                State = address.State,
                ZipCode = address.ZipCode,
                Country = address.Country,
                Latitude = address.Latitude,
                Longitude = address.Longitude
            };
        }
        public static void UpdateEntity(UpdateAddressDto dto, Address address)
        {
            address.Update(
                city: dto.City,
                state: dto.State,
                zipCode: dto.ZipCode,
                country: dto.Country,
                latitude: dto.Latitude,
                longitude: dto.Longitude
            );
        }
    }
}
