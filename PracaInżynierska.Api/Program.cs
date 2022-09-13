using PracaIn퓓nierska.Application.Interfaces;
using PracaIn퓓nierska.Application.Mappings;
using PracaIn퓓nierska.Application.Services;
using PracaIn퓓nierska.Domain.IRepositories;
using PracaIn퓓nierska.Infrastructure;
using PracaIn퓓nierska.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PIDbContext>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
