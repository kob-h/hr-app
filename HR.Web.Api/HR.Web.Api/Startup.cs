using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.AspNetCore;
using HR.Application.BusinessService.Employees;
using HR.Application.BusinessService.Interfaces;
using HR.Application.Dtos;
using HR.Application.Mappers;
using HR.Persistence.Database;
using HR.Persistence.Repositories;
using HR.Persistence.Repositories.Interfaces;
using HR.Web.Api.DtoValidators;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace HR.Web.Api
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
            services.AddDbContextPool<HRDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //services.AddDbContext<HRDbContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            services.AddControllers();

            services.AddMvc()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddEmployeeValidator>());
            
            services.AddTransient<IValidator<CreateEmployeeDto>, AddEmployeeValidator>();
            services.AddTransient<IValidator<CreateEmployeeAddressDto>, EmployeeAddressValidator>();

            services.AddTransient<ICreateEmployee, CreateEmployee>();
            services.AddTransient<IGetEmployeeById, GetEmployeeById>();
            services.AddTransient<IGetAllEmployees, GetAllEmployees>();

            services.AddTransient<IEmployeeRepository, EmployeeRepository>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            



            services.AddAutoMapper(typeof(EmployeeProfile));

            //added to avoid cyclic reference in serialization
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();



            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
