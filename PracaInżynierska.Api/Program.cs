

using PracaInzynierska.Application.Interfaces;
using PracaInzynierska.Application.MachineLearning;
using PracaInzynierska.Application.Mappings;
using PracaInzynierska.Application.Services;
using PracaInzynierska.Domain.IRepositories;
using PracaInzynierska.Infrastructure;
using PracaInzynierska.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PIDbContext>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IAssetTypeService, AssetTypeService>();
builder.Services.AddScoped<IFinancialChangeService, FinancialChangeService>();
builder.Services.AddScoped<IMachineLearning, MachineLearning>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IAssetTypeRepository, AssetTypeRepository>();
builder.Services.AddScoped<IFinancialChangeRepository, FinancialChangeRepository>();

builder.Services.AddSingleton(AutoMapperConfig.Initialize());

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
//app.Urls.Add("http://0.0.0.0:5000");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
