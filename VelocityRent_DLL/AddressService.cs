using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Velocity_Rent_DAL;
using VelocityRent.Dto;
using VelocityRent.Entities;
using FluentValidation;
using VelocityRent_DLL.Validators;

namespace VelocityRent_BLL
{
    public class AddressService
    {
        public int Create(AddressDto dto)
        {
            string error = Validate(dto);
            if(error != null) throw new Exception(error);

            Address address = MapToEntity(dto);
            return AddressRepository.InsertAddress(address);
        }

        private string Validate(AddressDto dto)
        {
            var Validator = new AddressDtoValidator();
            var result = Validator.Validate(dto);
            if(!result.IsValid)return result.Errors[0].ErrorMessage;
            return null;
        }
         
        private Address MapToEntity(AddressDto dto)
        {
            return new Address
            (
               dto.City,
               dto.State,
               dto.ZipCode,
               dto.Country,
               dto.Latitude,
               dto.Longitude
            );
        }

    }
}
