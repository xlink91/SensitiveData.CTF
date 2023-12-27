
using SensitiveData.CTF.BrownBox.App;
using SensitiveData.CTF.BrownBox.Domain;
using SensitiveData.CTF.BrownBox.Infrastructure;
using System.Reflection;

namespace SensitiveData.CTF.BrownBox
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.Register(builder.Configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }

    public static class RegisterServices
    {
        public static IServiceCollection Register(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ApiConfiguration>(configuration.GetSection(nameof(ApiConfiguration)));
            return services.AddScoped<ITokenizer, Tokenizer>()
                           .AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(TokenizeCardCommand).Assembly));
        }
    }
}