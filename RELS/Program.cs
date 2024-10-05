using Microsoft.EntityFrameworkCore;
using RELS.Context;
using RELS.Model;
using RELS.Repositories;
using RELS.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var conString = builder.Configuration.GetConnectionString("ConnectionString");
builder.Services.AddDbContext<RealEstateDbContext>(options => options.UseSqlServer(conString));



// Document
builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();
builder.Services.AddScoped<IDocumentService, DocumentService>();
// Favorite
builder.Services.AddScoped<IFavoriteRepository, FavoriteRepository>();
builder.Services.AddScoped<IFavoriteService, FavoriteService>();
// Lessor
builder.Services.AddScoped<ILessorRepository, LessorRepository>();
builder.Services.AddScoped<ILessorService, LessorService>();
// Owner
builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();
builder.Services.AddScoped<IOwnerService, OwnerService>();
// Permission
builder.Services.AddScoped<IPermissionRepository, PermissionRepository>();
builder.Services.AddScoped<IPermissionService, PermissionService>();
// Sector
builder.Services.AddScoped<ISectorRepository, SectorRepository>();
builder.Services.AddScoped<ISectorService, SectorService>();
// State
builder.Services.AddScoped<IStateRepository, StateRepository>();
builder.Services.AddScoped<IStateService, StateService>();
// TypeDocument
builder.Services.AddScoped<ITypeDocumentRepository, TypeDocumentRepository>();
builder.Services.AddScoped<ITypeDocumentService, TypeDocumentService>();
// TypeProperty
builder.Services.AddScoped<ITypePropertyRepository, TypePropertyRepository>();
builder.Services.AddScoped<ITypePropertyService, TypePropertyService>();
// User
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
// UserType
builder.Services.AddScoped<IUserTypeRepository, UserTypeRepository>();
builder.Services.AddScoped<IUserTypeService, UserTypeService>();
// Person
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPersonService, PersonService>();
// Property
builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();
builder.Services.AddScoped<IPropertyService, PropertyService>();


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
