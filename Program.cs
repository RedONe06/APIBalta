using Microsoft.EntityFrameworkCore;
using testeef.Data;

var builder = WebApplication.CreateBuilder(args);
//para versões a partir do 5.0 não existe mais a classe StartUp.

// Método ConfigureServices
// Add services to the container.
builder.Services.AddControllers();

// Utilizando um banco de dados em memória
builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database")); 

// Toda vez que for chamado um DataContext, vai ser chamado por uma mesma conexão no banco de dados e após a utilização
// vai fechar a conexão
builder.Services.AddScoped<DataContext, DataContext>(); 

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Método Configure
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // Força o HTTPS

app.UseAuthorization(); 

app.MapControllers();

app.Run();
