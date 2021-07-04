using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using MetricsAgent.DAL;
using MetricsAgent.DAL.Interface;
using MetricsAgent.DAL.Repository;
using MetricsAgent.DAL.SQLite;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NLog;
using ILogger = NLog.ILogger;

namespace MetricsAgent
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
            services.AddControllers();
            services.AddScoped<ICpuMetricsRepository, CpuMetricsRepository>();
            services.AddScoped<IDotNetMetricsRepository, DotNetMetricsRepository>();
            services.AddScoped<IHddMetricsRepository, HddMetricsRepository>();
            services.AddScoped<IRamMetricsRepository, RamMetricsRepository>();
            services.AddScoped<INetworkMetricsRepository, NetworkMetricsRepository>();
            services.AddSingleton<ILogger>(log);
            services.AddSingleton<IConnectionManager>(connection);
            ConfigureSqlLiteConnection();
        }
        
        private void ConfigureSqlLiteConnection()
        {
            var connectionString = Configuration.GetConnectionString("SqlLite");
            var connection = new SQLiteConnection(connectionString);
            connection.Open();
            PrepareSchema(connection);
        }

        private void PrepareSchema(SQLiteConnection connection)
        {
            using var command = new SQLiteCommand(connection);
            var Time = DateTimeOffset.Now;
            var tableList = new List<string>(){"CpuMetrics", "DotNetMetrics", "HddMetrics", "NetworkMetrics", "RamMetrics"};
            foreach (var table in tableList)
            {
                command.CommandText = @$"DROP TABLE IF EXISTS {table}";
                command.ExecuteNonQuery();
                command.CommandText = @$"CREATE TABLE {table}(id INTEGER PRIMARY KEY, value INT, time INTEGER)";
                command.ExecuteNonQuery();
                for (var i = 0; i < new Random().Next(3, 100); i++)
                {
                    command.CommandText = $"INSERT INTO {table}(Value, Time) VALUES({new Random().Next(0,100)}, {Time.ToUnixTimeSeconds()})";
                    command.ExecuteNonQuery();
                    Time = Time.AddMinutes(new Random().Next(1, 50));
                }
            }

                
            
            command.ExecuteNonQuery();
            
            DataGrip(connection);
        }

        private void DataGrip(SQLiteConnection connection)
        {
            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}