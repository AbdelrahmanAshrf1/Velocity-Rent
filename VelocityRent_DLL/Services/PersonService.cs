
using DTO;
using DTO.Address;
using DTO.Person;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Velocity_Rent_DAL;
using Velocity_Rent_DAL.Interfaces;
using VelocityRent.Entities;
using VelocityRent_DLL.Interfaces;
using VelocityRent_DLL.Mappers;
using VelocityRent_Utilities;

namespace VelocityRent_BLL.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepositroy _personRepo;
        private readonly IAddressRepository _addressRepo;
        private readonly IValidator<AddPersonDto> _addPersonvalidator;
        private readonly IValidator<UpdatePersonDto> _updatePersonvalidator;
        private readonly IValidator<AddAddressDto> _addAddressValidator;
        private readonly IValidator<UpdateAddressDto> _updateAddressValidator;
        public PersonService(
                IPersonRepositroy personRepo,
                IAddressRepository addressRepo,
                IValidator<AddPersonDto> addPersonvalidator,
                IValidator<UpdatePersonDto> updatePersonvalidator,
                IValidator<AddAddressDto> addAddressValidator,
                IValidator<UpdateAddressDto> updateAddressValidator)
        {
            _personRepo = personRepo;
            _addressRepo = addressRepo;
            _addPersonvalidator = addPersonvalidator;
            _updatePersonvalidator = updatePersonvalidator;
            _addAddressValidator = addAddressValidator;
            _updateAddressValidator = updateAddressValidator;
        }

        public bool Exists(int id) => _personRepo.Exists(id);
        public bool HasUser (int id) => _personRepo.HasUser(id);
        public Result<int> CreatePerson(CreatePersonRequest request)
        {

            var personValidationResult = _addPersonvalidator.Validate(request.PersonDto);
            if(!personValidationResult.IsValid)
            {
                LogValidationErrors(personValidationResult);
                return Result<int>.Failure("Invalid Person Data !");
            }

            var addressValidationResult = _addAddressValidator.Validate(request.AddressDto);
            if (!addressValidationResult.IsValid)
            {
                LogValidationErrors(addressValidationResult);
                return Result<int>.Failure("Invalid Address Data !");
            } 

            using (SqlConnection connection = DbConnectionFactory.CreateConnection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        Address address = AddressMapper.ToEntity(request.AddressDto);
                        int addressId = _addressRepo.Add(address, connection, transaction);
                    
                        Person person = PersonMapper.ToEntity(request.PersonDto, addressId);
                        int personId = _personRepo.Add(person, connection, transaction);
                  
                        transaction.Commit();
                        return Result<int>.Successful(personId);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Logger.Error(ex.ToString());
                        return Result<int>.Failure("Unexpected error.");
                    }
                }
            }
        }
        public Result<bool> UpdatePerson(UpdatePersonRequest request)
        {
            var personValidationResult = _updatePersonvalidator.Validate(request.PersonDto);
            if(!personValidationResult.IsValid)
            {
                LogValidationErrors(personValidationResult);
                return Result<bool>.Failure("Invalid Person Data !");
            }

            var addressValidationResult = _updateAddressValidator.Validate(request.AddressDto);
            if (!addressValidationResult.IsValid)
            {
                LogValidationErrors(addressValidationResult);
                return Result<bool>.Failure("Invalid Address Data !");
            }

            Address address = _addressRepo.GetByID(request.AddressDto.ID);
            if (address == null) return Result<bool>.Failure("Address not found.");

            Person person = _personRepo.GetByID(request.PersonDto.ID);
            if (person == null) return Result<bool>.Failure("Person not found.");

            using (SqlConnection connection = DbConnectionFactory.CreateConnection())
            { 
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        AddressMapper.UpdateEntity(request.AddressDto, address);
                        PersonMapper.UpdateEntity(request.PersonDto, person);

                        if (!_addressRepo.Update(address, connection, transaction))
                            throw new Exception("Updating address failed.");

                        if (!_personRepo.Update(person, connection, transaction))
                            throw new Exception("Updating person failed.");

                        transaction.Commit();
                        return Result<bool>.Successful(true);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Logger.Error(ex.ToString());
                        return Result<bool>.Failure("Unexpected error.");
                    }
                }
            }
        }
        public Result<bool> DeletePerson(int id)
        {
           
            if(!_personRepo.Exists(id)) return Result<bool>.Failure("Person not found.");

            return _personRepo.ChangeStatus(id,false)
                ? Result<bool>.Successful(true)
                : Result<bool>.Failure("Can not Deactivate the person.");
        }
        public PersonDto GetPersonByID(int id)
        {
            Person person = _personRepo.GetByID(id);

            return person == null ? null : PersonMapper.ToDto(person);
        }
        public List<PersonDto> GetAllPersons()
        {
            return _personRepo.GetAll().Select(PersonMapper.ToDto).ToList();
        }
        public Result<bool> Activate(int id)
        {
            if (!_personRepo.Exists(id)) return Result<bool>.Failure("Person not found.");

            return _personRepo.ChangeStatus(id, true)
                ? Result<bool>.Successful(true)
                : Result<bool>.Failure("Can not Activate the person.");
        }
        private void LogValidationErrors(FluentValidation.Results.ValidationResult result)
        {
            Logger.Error(string.Join(Environment.NewLine,result.Errors.Select(x => x.ErrorMessage)));
        }
    }
}
