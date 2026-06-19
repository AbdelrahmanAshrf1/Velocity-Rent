
using DTO;
using FluentValidation;
using Velocity_Rent_DAL.Interfaces;
using VelocityRent_DLL.Mappers;
using VelocityRent_Utilities;

namespace VelocityRent_DLL.Services
{
    public class PersonService
    {
        private readonly IPersonRepositroy _repo;
        private readonly PersonMapper _mapper;
        private readonly IValidator<AddPersonDto> _validator;
        public PersonService(IPersonRepositroy repo, PersonMapper mapper,IValidator<AddPersonDto> validator)
        {
            _repo = repo;
            _mapper = mapper;
            _validator = validator;
        }

        public int AddPerson(AddPersonDto dto)
        {
            var ValidationResult = _validator.Validate(dto);
            if(!ValidationResult.IsValid)
            {
                Logger.Error(ValidationResult.Errors.ToString());
                return -1;
            }
            var person = _mapper.ToEntity(dto);
            return _repo.Add(person);
        }
    }
}
