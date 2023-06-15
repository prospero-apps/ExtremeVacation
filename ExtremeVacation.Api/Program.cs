using ExtremeVacation.Api.Data;
using ExtremeVacation.Api.Repositories;
using ExtremeVacation.Api.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

namespace ExtremeVacation.Api
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

            builder.Services.AddDbContextPool<ExtremeVacationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ExtremeVacationConnection"))
            );

            builder.Services.AddScoped<ITripRepository, TripRepository>();
            builder.Services.AddScoped<ICartRepository, CartRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.          
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(policy =>
                policy.WithOrigins("http://localhost:7162", "https://localhost:7162")
                .AllowAnyMethod()
                .WithHeaders(HeaderNames.ContentType)
            );

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}