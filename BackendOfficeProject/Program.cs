using BackendOfficeProject.Context;
using BackendOfficeProject.Services;
using BackendOfficeProject.Services.IService;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
});

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<ICityService , CityService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IHeadDetailService, HeadDetailService>();
builder.Services.AddScoped<IDetailService, DetailService>();

builder.Services.AddDbContext<InMemoryDbContext>(options => options.UseInMemoryDatabase("InvoiceData"));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corsapp");

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
