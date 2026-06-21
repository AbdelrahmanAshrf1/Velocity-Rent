using DTO.Address;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Linq;
using Velocity_Rent_DAL.Interfaces;
using VelocityRent.Entities;
using VelocityRent_DLL.Mappers;
using VelocityRent_Utilities;

namespace VelocityRent_BLL
{
    public class AddressService 
    {
        private readonly IAddressRepository _repo;
        private readonly IValidator<AddAddressDto> _addAddressValidator;
        private readonly IValidator<UpdateAddressDto> _updateAddressValidator;
        public AddressService(
            IAddressRepository addressRepository,
            IValidator<AddAddressDto> addAddressValidator,
            IValidator<UpdateAddressDto> updateAddressValidator)
        {
            _repo = addressRepository;
            _addAddressValidator = addAddressValidator;
            _updateAddressValidator = updateAddressValidator;
        }

        public int AddAddress(AddAddressDto dto)
        {
            var validationResult = _addAddressValidator.Validate(dto);
            if(!validationResult.IsValid)
            {
                LogValidationResult(validationResult);
                return -1;
            }
            Address address = AddressMapper.ToEntity(dto);
            return _repo.Add(address);
        }
        public bool UpdateAddress(UpdateAddressDto dto)
        {
            var validationResult = _updateAddressValidator.Validate(dto);

            if(!validationResult.IsValid)
            {
                LogValidationResult(validationResult);
                return false;
            }

            Address address = _repo.GetByID(dto.ID);
            if(address == null) return false;

            AddressMapper.UpdateEntity(dto, address);
            return _repo.Update(address);
        }
        // Soft delete
        public bool Delete(int id)
        {
            Address address = _repo.GetByID(id);
            if(address == null) return false;
            address.Deactivate();
            return _repo.Update(address);
        }
        public AddressDto GetByID(int id)
        {
            Address address = _repo.GetByID(id);
            return address == null ? null : AddressMapper.ToDto(address);
        }

        private void LogValidationResult(ValidationResult Result)
        {
            Logger.Error(string.Join(Environment.NewLine, Result.Errors.Select(x => x.ErrorMessage)));
        }
    }
}
