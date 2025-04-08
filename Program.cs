using System.Text;
using itinera_io_backend.Context;
using itinera_io_backend.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<UserServices>();
builder.Services.AddScoped<TripServices>();
builder.Services.AddScoped<ActivityServices>();
builder.Services.AddScoped<ItineraryServices>();


var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddDbContext<DataContext>(options=>options.UseSqlServer(connectionString));


builder.Services.AddCors(options =>{
    options.AddPolicy("AllowAll",policy=>{ // create a cors policy with "AllowAll" as name
        policy.AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
        });
});

//get secret key from app settings
var secretKey = builder.Configuration["JWT:Key"];

//Add Auth Services to our app
builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme= JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options=>{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer =true, //check if token issue is valid
        ValidateAudience = true, //check if the token audience is valid
        ValidateLifetime = true, //check if token is not expired
        ValidateIssuerSigningKey = true, // Check the tokens signature is valid
        
        // ValidIssuer = "https://itineraioapi-cqapgsgcbschc7hu.westus-01.azurewebsites.net/",
        // ValidAudience= "https://itineraioapi-cqapgsgcbschc7hu.westus-01.azurewebsites.net/",
        ValidIssuer = "http://localhost:5000",
        ValidAudience= "http://localhost:5000",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
    };
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Allow Swagger in Production (Uncomment if needed)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Itinera V1");
    c.RoutePrefix = string.Empty; // Loads Swagger at the root URL
});

app.UseHttpsRedirection();

app.UseCors("AllowAll"); // policy nane AllowAll

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

