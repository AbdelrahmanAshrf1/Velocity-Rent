using DTO;
using DTO.Person;
using System;
using VelocityRent.Entities;

namespace VelocityRent_DLL.Mappers
{
    public static class PersonMapper
    {
        public static Person ToEntity(AddPersonDto dto)
        {
            return new Person(
                id: 0,
                firstName: dto.FirstName,
                lastName: dto.LastName,
                email: dto.Email,
                phone: dto.Phone,
                dateOfBirth: dto.DateOfBirth,
                nationalID: dto.NationalID,
                addressID: dto.AddressID,
                profileImage: dto.ProfileImage,
                createDate: DateTime.Now,
                isActive: true
            );
        }

        public static PersonDto ToDto(Person person)
        {
            return new PersonDto
            {
                ID = person.ID,
                FullName = $"{person.FirstName} {person.LastName}",
                Email = person.Email,
                Phone = person.Phone
            };
        }

        public static void UpdateEntity(
            UpdatePersonDto dto,
            Person person)
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