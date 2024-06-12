using GestaoInvestimentosInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Reflection;
using System.Diagnostics.CodeAnalysis;

namespace GestaoInvestimentosWebApi
{
    [ExcludeFromCodeCoverage]
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            builder.Services.AddLogging(builder =>
            {
                builder.AddSerilog().AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning);
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Gestão de Investimentos", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                opt.IncludeXmlComments(xmlPath);
            });

            string? connectionString = configuration.GetConnectionString("DefaultConnection");
            string? commandTimeout = configuration.GetSection("AppSettings:CommandTimeout")?.Value;

            if (!string.IsNullOrEmpty(connectionString))
            {
                builder.Services.AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseSqlServer(connectionString, sqlO => sqlO.CommandTimeout(Int32.Parse(commandTimeout)))
                    .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Warning)))
                    .EnableSensitiveDataLogging(false);
                }, ServiceLifetime.Scoped);
            }
            else
                Log.Logger.Fatal("Variável de ambiente: ConnectionString não encontrada.");

            builder.Services.AddServices().AddRepositories();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                    policy =>
                                    {
                                        policy.WithOrigins("http://localhost:4200")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                                    });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
                app.UseCors(MyAllowSpecificOrigins);
            }

            app.UseReDoc(c =>
            {
                c.DocumentTitle = "REDOC Gestão de Investimetos API";
                c.RoutePrefix = "";
            });

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
