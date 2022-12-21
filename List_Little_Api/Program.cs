using System.Text.Json;
using List_Little_Business.Services;
using List_Little_Business_Contracts.Services;
using List_Little_Infrastructure.Database;
using List_Little_Infrastructure.Repositories;
using List_Little_Infrastructure_Contracts.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddTransient<IPersonService, PersonService>();
builder.Services.AddTransient<IPersonRepository, PersonRepository>();

builder.Services.AddAuthentication()
     .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
     {
         options.Authority = $"https://{builder.Configuration["Auth0:Domain"]}";
         options.TokenValidationParameters =
           new Microsoft.IdentityModel.Tokens.TokenValidationParameters
           {
               ValidAudience = builder.Configuration["Auth0:Audience"],
               ValidIssuer = $"{builder.Configuration["Auth0:Domain"]}"
           };
     });
builder.Services.AddAuthorization();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();

    dbContext.Database.EnsureDeleted();
    dbContext.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
