using ClientesMinimalApi.Data;
using ClientesMinimalApi.Models;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("PostgreSQLConnection");
builder.Services.AddDbContext<ClientsDb>(options =>
        options.UseNpgsql(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/clientes/", async (Clientes c, ClientsDb db) =>
{
    db.Clientes.Add(c);
    await db.SaveChangesAsync();

    return Results.Created($"/clientes/{c.Id}", c);
});

app.MapGet("/clientes/{id:int}", async (int id, ClientsDb db)=>
{
    return await db.Clientes.FindAsync(id)
    is Clientes c
    ? Results.Ok(c)
    : Results.NotFound();
});

app.MapGet("/clientes/", async (ClientsDb db) => await db.Clientes.ToListAsync());

app.MapPut("/clientes/{id:int}", async (int id, Clientes c, ClientsDb db) =>
{
    if(c.Id != id)
        return Results.BadRequest();

    var cliente = await db.Clientes.FindAsync(id);

    if (cliente is null) return Results.NotFound();

    cliente.Nombre = c.Nombre;
    cliente.Apellido = c.Apellido;
    cliente.Puesto = c.Puesto;
    cliente.Edad = c.Edad;

    await db.SaveChangesAsync();
    return Results.Ok(cliente);

});

app.MapDelete("/clientes/{id:int}", async (int id, ClientsDb db) => 
{
    var cliente = await db.Clientes.FindAsync(id);

    if (cliente is null) return Results.NotFound();

    db.Clientes.Remove(cliente);
    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
