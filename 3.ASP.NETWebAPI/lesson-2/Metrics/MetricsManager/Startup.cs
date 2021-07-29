using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dapper;
using FluentMigrator.Runner;
using MetricsManager.Client;
using MetricsManager.Client.Interface;
using MetricsManager.Controllers;
using MetricsManager.DAL;
using MetricsManager.DAL.Interface;
using MetricsManager.DAL.Jobs;
using MetricsManager.DAL.Repository;
using MetricsManager.DAL.SQLite;
using MetricsManager.Mapper;
using MetricsManager.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NLog;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using Polly;
using CpuMetricsRepository = MetricsManager.DAL.Repository.CpuMetricsRepository;

namespace MetricsManager
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var log = LogManager.GetCurrentClassLogger();
            var connection = new ConnectionManager(Configuration);
            var mapperConfiguration = new MapperConfiguration(mp => mp.AddProfile(new MapperProfile()));
            var mapper = mapperConfiguration.CreateMapper();
            var connectionString = Configuration.GetConnectionString("SqlLite");
            services.AddControllers();
            services.AddSingleton<IAgentsRepository, AgentsRepository>();
            services.AddSingleton<ICpuMetricsRepository, CpuMetricsRepository>();
            services.AddSingleton<AgentsList>();
            services.AddSingleton<ILogger>(log);
            services.AddSingleton<IConnectionManager>(connection);
            services.AddSingleton(mapper);
            ConfigureMapper();
            services.AddFluentMigratorCore().ConfigureRunner(e => e.AddSQLite()
                    .WithGlobalConnectionString(connectionString)
                    .ScanIn(typeof(Startup).Assembly)
                    .For
                    .Migrations())
                .AddLogging(l => l.AddFluentMigratorConsole());
            services.AddSingleton<IJobFactory, SingletonJobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            services.AddSingleton<CpuMetricJob>();
            services.AddSingleton(new JobSchedule(jobType: typeof(CpuMetricJob), cronExpression: "0/50 * * * * ?"));
            services.AddHttpClient<ICpuMetricsAgentClient, CpuMetricsAgentClient>().AddTransientHttpErrorPolicy(p => 
                p.WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(1000)));
            services.AddHostedService<QuartzHostedService>();
        }
        
        private void ConfigureMapper()
        {
            SqlMapper.AddTypeHandler(new DateTimeOffsetMappingHandler());
            SqlMapper.RemoveTypeMap(typeof(DateTimeOffset));
            SqlMapper.RemoveTypeMap(typeof(DateTimeOffset?));
            
            SqlMapper.AddTypeHandler(new UriMappingHandler());
            SqlMapper.RemoveTypeMap(typeof(Uri));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMigrationRunner migrationRunner)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            
            migrationRunner.MigrateUp();
        }
    }
}