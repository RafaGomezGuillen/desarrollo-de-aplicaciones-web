using Microsoft.EntityFrameworkCore;
using Ejercicio2RafaGomez.Data;
using System.Text.Json.Serialization;

internal class Program
{
    private static void Main (string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers().AddJsonOptions(x =>
        {
            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });

        builder.Services.AddDbContext<MyDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("Ejercicio2RafaGomezContext"));
            //options.UseInMemoryDatabase("GameGenre");
        });

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

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