using BarberShop.Context;
using BarberShop.Model;
using BarberShop.UnitOfWork.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

// Add Seri-log
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File("logs/ResponseInformation.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c=>
{
    c.MapType<Role>(() => new OpenApiSchema
    {
        Type = "string",
        Enum = Enum.GetNames(typeof(Role))
                   .Select(n => new OpenApiString(n))
                   .Cast<IOpenApiAny>()
                   .ToList()
    });

});

builder.Services.AddDbContext<BarberShopDbContext>(option =>
option.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]));
builder.Services.AddIdentity<T_User, IdentityRole>(option =>
{
    option.User.RequireUniqueEmail = false;


}).AddEntityFrameworkStores<BarberShopDbContext>();

builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<UpdateUserService>();
builder.Services.AddScoped<DeleteUserService>();


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
