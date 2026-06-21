
using DTO;
using DTO.Person;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using Velocity_Rent_DAL.Interfaces;
using VelocityRent.Entities;
using VelocityRent_DLL.Mappers;
using VelocityRent_Utilities;

namespace VelocityRent_DLL.Services
{
    public class PersonService
    {
        private readonly IPersonRepositroy _repo;
        private readonly IValidator<AddPersonDto> _addPersonvalidator;
        private readonly IValidator<UpdatePersonDto> _updatePersonvalidator;
        public PersonService(
                IPersonRepositroy repo,
                IValidator<AddPersonDto> addPersonvalidator,
                IValidator<UpdatePersonDto> updatePersonvalidator)
        {
            _repo = repo;
            _addPersonvalidator = addPersonvalidator;
            _updatePersonvalidator = updatePersonvalidator;
        }

        public int AddPerson(AddPersonDto dto)
        {
            var validationResult = _addPersonvalidator.Validate(dto);
            if(!validationResult.IsValid)
            {
                LogValidationErrors(validationResult);
                return -1;
            }
            var person = PersonMapper.ToEntity(dto);
            return _repo.Add(person);
        }

        public bool UpdatePerson(UpdatePersonDto dto)
        {
            var validationResult = _updatePersonvalidator.Validate(dto);

            if(!validationResult.IsValid)
            {
                LogValidationErrors(validationResult);
                return false;
            }

            Person person = _repo.GetByID(dto.ID);
            if(person == null) return false; 
            
            PersonMapper.UpdateEntity(dto, person);

            return _repo.Update(person);
        }

        // Soft delete
        public bool DeletePerson(int id)
        {
            Person person = _repo.GetByID(id);
            if(person == null) return false;

            person.Deactivate();
            return _repo.Update(person);
        }

        public PersonDto GetPersonByID(int id)
        {
            Person person = _repo.GetByID(id);

            return person == null ? null : PersonMapper.ToDto(person);
        }
        public List<PersonDto> GetAllPersons()
        {
            return _repo.GetAll().Select(PersonMapper.ToDto).ToList();
        }
        
        private void LogValidationErrors(FluentValidation.Results.ValidationResult result)
        {
            Logger.Error(string.Join(Environment.NewLine,result.Errors.Select(x => x.ErrorMessage)));
        }

    }
}
