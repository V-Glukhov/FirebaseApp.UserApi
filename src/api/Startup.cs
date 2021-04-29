using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;
using UserApi.BL.Contracts.Commands;
using UserApi.BL.UserService.CommandHandlers;
using UserApi.DAL.Repository.Abstraction;
using UserApi.DAL.Repository.Implementation;
using UserApi.MapProfiles;

namespace UserApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "User API", Version = "v1" });
            });

            AddMediatrService(services);
            AddMapperServices(services);
            AddRepositories(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "User API"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AddMediatrService(IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly()); ;
            services.AddScoped<IRequestHandler<RegisterNewAppCommand, bool>, RegisterNewAppCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteAppRegistrationCommand, bool>, DeleteAppRegistrationCommandHandler>();
        }

        private void AddRepositories(IServiceCollection services)
        {
            services.AddSingleton<IUserRepository, UserRepository>();
        }

        private void AddMapperServices(IServiceCollection services)
        {
            services.AddSingleton<IMapper>(new Mapper(GetMapperConfiguration()));
        }

        private static AutoMapper.IConfigurationProvider GetMapperConfiguration()
        {
            var conf = new MapperConfiguration(x =>
            {
                x.AddProfile<UserServiceProfile>();
                x.AddProfile<BL.UserService.MapProfiles.UserServiceProfile>();
            });

            conf.AssertConfigurationIsValid();
            return conf;
        }
    }
}
