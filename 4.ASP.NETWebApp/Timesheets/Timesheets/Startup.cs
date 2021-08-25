using System.Reflection;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Timesheets.DAL;
using Timesheets.DAL.Interfaces;
using Timesheets.DAL.Repositories;
using Timesheets.Mapper;

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
            });
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IContractRepository, ContractRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ITaskEmployeeRepository, TaskEmployeeRepository>();
            services.AddScoped<DataBaseContext>();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            var mapperConfiguration = new MapperConfiguration(mp => mp.AddProfile(new MapperProfile()));
            var mapper = mapperConfiguration.CreateMapper(); 
            services.AddSingleton(mapper);
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}