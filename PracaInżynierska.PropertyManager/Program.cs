
using NSwag.AspNetCore;
using PracaIn퓓nierska.Application.Interfaces;
using PracaIn퓓nierska.Application.Mappings;
using PracaIn퓓nierska.Application.Services;
using PracaIn퓓nierska.Domain.IRepositories;
using PracaIn퓓nierska.Infrastructure;
using PracaIn퓓nierska.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<PIDbContext>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddSingleton(AutoMapperConfig.Initialize());

builder.Services.AddControllersWithViews();


builder.Services.AddSwaggerDocument();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.

    app.UseHsts();
    

}
app.UseOpenApi();
app.UseSwaggerUi3();
app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();
app.UseStaticFiles(new StaticFileOptions()
{
    OnPrepareResponse = (context) =>
    {
        context.Context.Response.Headers["Cache-Control"] = app.Configuration["StaticFiles:Headers:Cache-Control"];
        context.Context.Response.Headers["Pragma"] = app.Configuration["StaticFiles:Headers:Pragma"];
        context.Context.Response.Headers["Expires"] = app.Configuration["StaticFiles:Headers:Expires"];
    }
});
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

//app.MapFallbackToFile("index.html"); ;
//app.MapWhen(r => !r.Request.Path.Value.StartsWith("/swagger"), builder2 =>
//{
//    app.MapFallbackToFile("index.html");
//});
app.Run();
