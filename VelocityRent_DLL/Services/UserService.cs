using DTO;
using DTO.User;
using FluentValidation;
using System;
using System.Linq;
using Velocity_Rent_DAL.Interfaces;
using VelocityRent.Entities;
using VelocityRent_DLL.Mappers;
using VelocityRent_Utilities;

namespace VelocityRent_DLL.Services
{
    public class UserService
    {
        private readonly IUserRepositroy _repo;
        private readonly IValidator<AddUserDto> _addUserDtoValidator; 
        private readonly IValidator<UpdateUserDto> _updateUserDtoValidator; 
        private readonly IValidator<ChangePasswordDto> _changePasswordDtoValidator; 

        public UserService(
            IUserRepositroy repo,
            IValidator<AddUserDto> addUserDtoValidator,
            IValidator<UpdateUserDto> updateUserDtoValidator,
            IValidator<ChangePasswordDto> changePasswordDtoValidator)
        {
            _repo = repo;
            _addUserDtoValidator = addUserDtoValidator;
            _updateUserDtoValidator = updateUserDtoValidator;
            _changePasswordDtoValidator = changePasswordDtoValidator;
        }

        public int AddUser(AddUserDto dto)
        { 
            var validationResult = _addUserDtoValidator.Validate(dto);

            if (!validationResult.IsValid)
            {
                LogValidationErrors(validationResult);
                return -1;
            }

            dto.Password = PasswordHasher.HashPassword(dto.Password);
            User user = UserMapper.ToEntity(dto);
            return _repo.Add(user);
        }

        private void LogValidationErrors(FluentValidation.Results.ValidationResult result)
        {
            Logger.Error(string.Join(Environment.NewLine, result.Errors.Select(x => x.ErrorMessage)));
        }
    }
}
