using GestaoInvestimentosInfrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GestaoInvestimentosWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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

            builder.Services.AddServices().AddRepositories();

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
