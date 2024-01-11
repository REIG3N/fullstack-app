using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FullStack.Core.Mappings;
using FullStack.Repo.Data;
using FullStack.Service.Filters.ActionFilter;
using FullStack.Service.Interfaces;
using FullStack.Service.Services;


namespace FullStackAPI.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureLoggerService(this IServiceCollection services) =>
        services.AddScoped<ILoggerManager, LoggerManager>();

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<RepositoryContext>(
                opts => opts.UseSqlServer(configuration.GetConnectionString("FullStackConnectionString"),
                    b => b.MigrationsAssembly("FullStack.Repo")));

        public static void ConfigureRepositoryManager(this IServiceCollection services)
            => services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureMapping(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });
            var mapperConfig = new MapperConfiguration(map =>
            {
                map.AddProfile<DepartementMappingProfile>();
                map.AddProfile<EmployeeMappingProfile>();
            });
            services.AddSingleton(mapperConfig.CreateMapper());
        }

        //Add Here
        public static void ConfigureControllers(this IServiceCollection services)
        {
            services.AddControllers(config =>
            {
                config.CacheProfiles.Add("120SecondsDuration", new CacheProfile
                {
                    Duration = 30
                });
            });
        }

        //Add Here
        public static void ConfigureResponseCaching(this IServiceCollection services) => services.AddResponseCaching();


        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddScoped<ValidationFilterAttribute>();
            services.AddScoped<ValidateDepartementExists>();
            services.AddScoped<ValidateEmployeeExistsForDepartement>();
        }
    }
}
