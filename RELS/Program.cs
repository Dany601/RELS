using Microsoft.EntityFrameworkCore;
using RELS.Context;
using RELS.Repositories;
using RELS.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var conString = builder.Configuration.GetConnectionString("ConnectionString");
builder.Services.AddDbContext<RealEstateDbContext>(options => options.UseSqlServer(conString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPermissionXUserRepository, PermissionXUserRepository>();
builder.Services.AddScoped<IPermissionXUserService, PermissionXUserService>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();
builder.Services.AddScoped<IPropertyService, PropertyService>();
builder.Services.AddScoped<IPropertyXLessorRepository, PropertyXLessorRepository>();
builder.Services.AddScoped<IPropertyXLessorService, PropertyXLessorService>();
builder.Services.AddScoped<IPropertyXOwnerRepository, PropertyXOwnerRepository>();
builder.Services.AddScoped<IPropertyXOwnerService, PropertyXOwnerService>();

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
