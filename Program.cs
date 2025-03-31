using itinera_io_backend.Context;
using itinera_io_backend.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<UserServices>();
builder.Services.AddScoped<TripServices>();

var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddDbContext<DataContext>(options=>options.UseSqlServer(connectionString));

builder.Services.AddCors(options =>{
    options.AddPolicy("AllowAll",policy=>{ // create a cors policy with "AllowAll" as name
        policy.AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll"); // policy nane AllowAll

app.UseAuthorization();

app.MapControllers();

app.Run();
