using SistemaGestionAPI.Models;

using SistemaGestionData;

namespace SistemaGestionAPI;

public class Program
{
  public static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);

    Connection.DatabaseConnection = GestorBaseDatos.Inicializacion(
      server: builder.Configuration.GetValue<string>("ConnectionString:Server"),
      database: builder.Configuration.GetValue<string>("ConnectionString:Database"),
      user: builder.Configuration.GetValue<string>("ConnectionString:User"),
      password: builder.Configuration.GetValue<string>("ConnectionString:Password")
    );

    Connection.DatabaseConnection.Open();
    Connection.DatabaseConnection.ChangeDatabase(builder.Configuration.GetValue<string>("ConnectionString:Database"));

    // Add services to the container.

    builder.Services.AddControllers();
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

    Connection.DatabaseConnection.Close();
  }
}