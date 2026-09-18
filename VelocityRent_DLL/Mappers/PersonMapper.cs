using DTO;
using DTO.Person;
using VelocityRent.Entities;

namespace VelocityRent_DLL.Mappers
{
    public static class PersonMapper
    {
        public static Person ToEntity(AddPersonDto dto,int AddressID)
        {
            return new Person(
                firstName: dto.FirstName,
                lastName: dto.LastName,
                email: dto.Email,
                phone: dto.Phone,
                dateOfBirth: dto.DateOfBirth,
                nationalID: dto.NationalID,
                addressID: AddressID,
                profileImage: dto.ProfileImage
            );
        }

        public static PersonDto ToDto(Person person)
        {
            return new PersonDto
            {
                ID = person.ID,
                FullName = person.FirstName + " " + person.LastName,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Email = person.Email,
                Phone = person.Phone,
                AddressID = person.AddressID,
                NationalID = person.NationalID,
                DateOfBirth = person.DateOfBirth,
                ProfileImage = person.ProfileImage,
                Active = person.IsActive

            };
        }

        public static void UpdateEntity(UpdatePersonDto dto,Person person)
        {
            person.Update(
                firstName: dto.FirstName,
                lastName: dto.LastName,
                email: dto.Email,
                phone: dto.Phone,
                dateOfBirth: dto.DateOfBirth,
                profileImage: dto.ProfileImage
            );
        }
    }
}