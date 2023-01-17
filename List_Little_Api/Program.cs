using System.Security.Claims;
using System.Text.Json;
using List_Little_Business.Services;
using List_Little_Business_Contracts.Services;
using List_Little_Infrastructure.Database;
using List_Little_Infrastructure.Repositories;
using List_Little_Infrastructure_Contracts.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddTransient<IPersonService, PersonService>();
builder.Services.AddTransient<IPersonRepository, PersonRepository>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.Authority = builder.Configuration["Auth0:Domain"];
    options.Audience = builder.Configuration["Auth0:Audience"];
});

builder.Services.AddAuthorization(o =>
{
    o.AddPolicy("Access", p => p.
        RequireAuthenticatedUser().
        RequireClaim("permissions", "listlittle:access"));

    o.AddPolicy("Admin", p => p.
        RequireAuthenticatedUser().
        RequireClaim("permissions", "listlittle:read-write"));

    o.AddPolicy("User1", p => p.
        RequireAuthenticatedUser().
        RequireClaim("permissions", "listlittle:read-write-one-eight"));

    o.AddPolicy("User2", p => p.
        RequireAuthenticatedUser().
        RequireClaim("permissions", "listlittle:read-write-nine-sixteen"));
});

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

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
