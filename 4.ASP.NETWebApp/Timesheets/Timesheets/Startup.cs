using System;
using System.Reflection;
using System.Text;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Timesheets.Behaviours;
using Timesheets.DAL.EF;
using Timesheets.DAL.Interfaces;
using Timesheets.DAL.Repositories;
using Timesheets.Mapper;
using Timesheets.Service.Authentication;
using Timesheets.Validations;

namespace Timesheets
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(setup =>
            {
                setup.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Timesheets",
                    Contact = new OpenApiContact
                    {
                        Name = "lameR",
                    },
                });
                setup.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                }); 
                setup.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
            
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IContractRepository, ContractRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ITaskEmployeeRepository, TaskEmployeeRepository>();
            services.AddScoped<DataBaseContext>();
            services.AddSingleton<IUserService, UserService>();	
            services.AddSingleton<IErrorCodes, ErrorCodes>();
            services.AddCors();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            var mapperConfiguration = new MapperConfiguration(mp => mp.AddProfile(new MapperProfile()));
            var mapper = mapperConfiguration.CreateMapper(); 
            services.AddSingleton(mapper);
            services.AddControllers();
            services.AddDbContext<DataBaseContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("Postgres"),
                    b=>b.MigrationsAssembly("Timesheets"))
                    .UseLoggerFactory(LoggerFactory.Create(builder =>
                    {
                        builder
                            .AddConsole((_) => { })
                            .AddFilter((category, level) =>
                                category == DbLoggerCategory.Database.Command.Name 
                                && level == LogLevel.Information);
                    }));
            });
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(UserService.SecretCode)),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.Zero
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Timesheets v1"));
            }
            
            app.UseRouting();
            app.UseCors(x => x
                .SetIsOriginAllowed(_ => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
