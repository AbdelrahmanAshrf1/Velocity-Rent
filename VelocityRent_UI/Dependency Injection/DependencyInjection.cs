using DTO;
using DTO.User;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Velocity_Rent.Login_Form;
using Velocity_Rent_DAL.Interfaces;
using Velocity_Rent_DAL.Repositories;
using VelocityRent.Validators.Validators.User;
using VelocityRent_DLL.Interfaces;
using VelocityRent_DLL.Services;

namespace Velocity_Rent.Dependency_Injection
{
    public static class DependencyInjection
    {
        public static ServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddTransient<IUserRepository,UserRepository>();

            services.AddTransient<IUserService,UserService>();

            services.AddTransient<IValidator<LoginDto>, LoginDtoValidator>();
            services.AddTransient<IValidator<AddUserDto>, AddUserDtoValidator>();
            services.AddTransient<IValidator<UpdateUserDto>, UpdateUserDtoValidator>();
            services.AddTransient<IValidator<ChangePasswordDto>, ChangePasswordDtoValidator>();

            services.AddTransient<frmLogin>();
            services.AddTransient<frmMain>();

            services.AddSingleton<IRememberMeService, RememberMeService>();

            return services.BuildServiceProvider();
        }
    }
}
