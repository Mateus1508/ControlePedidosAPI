using Controle_de_pedidos;
using Controle_de_pedidos.Repositories;
using Controle_de_pedidos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ControlePedidosDbContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("Database"))
    );

builder.Services.AddScoped<IItensDePedidoRepository, ItensDePedidoRepository>();
builder.Services.AddScoped<IPedidosRepository, PedidosRepository>();
builder.Services.AddScoped<IProdutosRepository, ProdutosRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
