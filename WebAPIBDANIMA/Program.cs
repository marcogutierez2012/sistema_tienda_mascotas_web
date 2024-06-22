using WebAPIBDANIMA.DAO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<EmpleadoDAO>();
builder.Services.AddScoped<ConsultorDAO>();
builder.Services.AddScoped<ClienteDAO>();
builder.Services.AddScoped<VentaDAO>();
builder.Services.AddScoped<ProductoDAO>();
builder.Services.AddScoped<UsuarioDAO>();

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
