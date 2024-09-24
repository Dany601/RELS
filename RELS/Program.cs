using Microsoft.EntityFrameworkCore;
using RELS.Context;
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
builder.Services.AddScoped<IDocumentRepository, FavoriteRepository>();
builder.Services.AddScoped<IDocumentService, FavoriteRepository>();
// Lessor
builder.Services.AddScoped<IDocumentRepository, LessorRepository>();
builder.Services.AddScoped<IDocumentService, LessorRepository>();
// Owner
builder.Services.AddScoped<IDocumentRepository, OwnerRepository>();
builder.Services.AddScoped<IDocumentService, OwnerRepository>();
// Permission
builder.Services.AddScoped<IDocumentRepository, PermissionRepository>();
builder.Services.AddScoped<IDocumentService, PermissionRepository>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
