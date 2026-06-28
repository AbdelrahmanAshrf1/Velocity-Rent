using DTO;
using DTO.User;
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
    public class UserService
    {
        private readonly IUserRepositroy _repo;
        private readonly IValidator<LoginDto> _loginDtoValidator;
        private readonly IValidator<AddUserDto> _addUserDtoValidator; 
        private readonly IValidator<UpdateUserDto> _updateUserDtoValidator; 
        private readonly IValidator<ChangePasswordDto> _changePasswordDtoValidator; 

        public UserService(
            IUserRepositroy repo,
            IValidator<LoginDto> loginDtoValidator,
            IValidator<AddUserDto> addUserDtoValidator,
            IValidator<UpdateUserDto> updateUserDtoValidator,
            IValidator<ChangePasswordDto> changePasswordDtoValidator)
        {
            _repo = repo;
            _loginDtoValidator = loginDtoValidator;
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
        public bool UpdateUser(UpdateUserDto dto)
        {
            var validationResult = _updateUserDtoValidator.Validate(dto);

            if(!validationResult.IsValid)
            {
                LogValidationErrors(validationResult);
                return false;
            }

            User user = _repo.GetByID(dto.Id);
            if (user == null) return false;
        
            user.ChangeRole(dto.UserRole);
            user.ChangeUsername(dto.Username);

            return _repo.Update(user);
        }
        public bool Activate(int id) => _repo.SetActive(id, true);
        public bool Deactivate(int id) => _repo.SetActive(id, false);
        public bool ChangePassword(ChangePasswordDto dto)
        {
            var validationResult = _changePasswordDtoValidator.Validate(dto);

            if (!validationResult.IsValid)
            {
                LogValidationErrors(validationResult);
                return false;
            }

            if (!_repo.Exists(dto.Id)) return false;
            string hash = PasswordHasher.HashPassword(dto.NewPassword);
            return _repo.ChangePassword(dto.Id, hash);
        }
        public bool Exists(int id) => _repo.Exists(id);
        public UserDto GetUserByID(int id)
        {
            User user = _repo.GetByID(id);
            return user == null ? null : UserMapper.ToDto(user);
        }
        public List<UserDto> GetAllUsers()
        {
            List<User> users = _repo.GetAll();

            if(users == null) return null;

            return users.Select(UserMapper.ToDto).ToList();
        }
        public bool UpdateLastLogin(int id) => _repo.UpdateLastLogin(id);
        private void LogValidationErrors(FluentValidation.Results.ValidationResult result)
        {
            Logger.Error(string.Join(Environment.NewLine, result.Errors.Select(x => x.ErrorMessage)));
        }
        public User Authenticate(string username, string password)
        {
            User user = _repo.GetByUsername(username);
            if(user == null) return null;

            bool isValid = PasswordHasher.VerifyPassword(password, user.PasswordHash);
            return isValid? user : null;
        }
        public Result<UserDto> Login(LoginDto dto)
        {
            var validationResult = _loginDtoValidator.Validate(dto);

            if (!validationResult.IsValid)
            {
                LogValidationErrors(validationResult);
                return Result<UserDto>.Failed("Invalid login data.");
            }

            User user = Authenticate(dto.Username, dto.Password);

            if (user == null) return Result<UserDto>.Failed("Invalid username or password.");
            if (!user.IsActive) return Result<UserDto>.Failed("Your account is disabled.");

            _repo.UpdateLastLogin(user.ID);

            return Result<UserDto>.Successful(UserMapper.ToDto(user));
        }
    }
}
