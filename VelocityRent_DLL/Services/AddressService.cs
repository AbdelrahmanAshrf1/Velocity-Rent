using AutoMapper;
using DTO.Address;
using FluentValidation;
using System;
using Velocity_Rent_DAL.Interfaces;
using VelocityRent.Entities;
using VelocityRent_DLL.Services;

namespace VelocityRent_BLL
{
    public class AddressService 
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IValidator<CreateAddressDto> _createValidator;
        private readonly IValidator<UpdateAddressDto> _updateValidator;
        public AddressService(
            IMapper mapper,
            IAddressRepository addressRepository,
            IValidator<CreateAddressDto> createValidator,
            IValidator<UpdateAddressDto> updateValidator)
            : base(mapper)
        {
            _addressRepository = addressRepository;
            _updateValidator = updateValidator;
            _createValidator = createValidator;
        }

        public int Add(CreateAddressDto dto)
        {
            Validate(_createValidator, dto);
            Address newAddress = new Address
            (
                0, 
                dto.City,
                dto.State,
                dto.ZipCode,
                dto.Country,
                dto.Latitude,
                dto.Longitude
            );
            return _addressRepository.Add(newAddress);
        }
        public bool Update(UpdateAddressDto dto)
        {
            Validate(_updateValidator, dto);
            Address existingAddress = _addressRepository.GetByID(dto.ID);
            if (existingAddress == null) throw new Exception("Address not found.");
            existingAddress.Update
            (
                dto.City,
                dto.State,
                dto.ZipCode,
                dto.Country,
                dto.Latitude,
                dto.Longitude
            );
            return _addressRepository.Update(existingAddress);
        }
        public bool Delete(int id) => _addressRepository.Delete(id);
        public ViewAddressDto GetByID(int id)
        {
            Address address = _addressRepository.GetByID(id);
            if (address == null) throw new Exception("Address not found.");
            ViewAddressDto dto = _mapper.Map<ViewAddressDto>(address);
            return dto;
        }
    }
}
