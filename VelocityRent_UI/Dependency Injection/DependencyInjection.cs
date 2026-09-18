using DTO;
using DTO.Address;
using DTO.Person;
using DTO.User;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Velocity_Rent.Forms.Address;
using Velocity_Rent.Forms.People;
using Velocity_Rent.Forms.Users;
using Velocity_Rent.Login_Form;
using Velocity_Rent_DAL;
using Velocity_Rent_DAL.Interfaces;
using Velocity_Rent_DAL.Repositories;
using VelocityRent.Validators.Validators.Address;
using VelocityRent.Validators.Validators.Person;
using VelocityRent.Validators.Validators.User;
using VelocityRent_BLL.Services;
using VelocityRent_DLL.Interfaces;
using VelocityRent_DLL.Services;
using VelocityRent_DLL.Validators.Address;

namespace Velocity_Rent.Dependency_Injection
{
    public static class DependencyInjection
    {
        public static ServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<IPersonRepositroy, PersonRepository>();
            services.AddTransient<IUserRepository,UserRepository>();

            services.AddTransient<IAddressService,AddressService>();
            services.AddTransient<IPersonService,PersonService>();
            services.AddTransient<IUserService,UserService>();

            services.AddTransient<IValidator<LoginDto>, LoginDtoValidator>();
            services.AddTransient<IValidator<AddUserDto>, AddUserDtoValidator>();
            services.AddTransient<IValidator<UpdateUserDto>, UpdateUserDtoValidator>();
            services.AddTransient<IValidator<ChangePasswordDto>, ChangePasswordDtoValidator>();
            services.AddTransient<IValidator<AddPersonDto>, AddPersonDtoValidator>();
            services.AddTransient<IValidator<UpdatePersonDto>, UpdatePersonDtoValidator>();
            services.AddTransient<IValidator<AddAddressDto>, AddAddressDtoValidator>();
            services.AddTransient<IValidator<UpdateAddressDto>, UpdateAddressDtoValidator>();

            services.AddTransient<frmLogin>();
            services.AddTransient<frmMain>();
            services.AddTransient<frmPersonEditor>();
            services.AddTransient<frmAddressEditor>();
            services.AddTransient<frmPersonDirectory>();
            services.AddTransient<frmUserEditor>();

            services.AddSingleton<IRememberMeService, RememberMeService>();

            return services.BuildServiceProvider();
        }
    }
}
