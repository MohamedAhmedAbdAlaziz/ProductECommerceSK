using Infrastructure.Data;
using Core.Interfaces;
using Microsoft.OpenApi.Models;
using Infrastrucrture.Data;
using Microsoft.EntityFrameworkCore;
using API.Helpers;
using API.Middleware;
using Microsoft.AspNetCore.Mvc;
using API.Errors;
using API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(typeof(MappingProfiles));

builder.Services.AddControllers();
builder.Services.AddDbContext<StoreContext>(x=> x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddApplicationServices();
builder.Services.AddswaggerDocmentation();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();





var host = builder.Build();
using(var scope = host.Services.CreateAsyncScope()){
 var services= scope.ServiceProvider;

 var loggerFactory= services.GetRequiredService<ILoggerFactory>();
 try{
    var context=services.GetRequiredService<StoreContext>();
    await context.Database.MigrateAsync();
    await StoreContextSeed.SeedAsync(context,loggerFactory);
 }
 catch(Exception ex){
    var logger= loggerFactory.CreateLogger<Program>();
    logger.LogError(ex,"An error occured during migrations");
 }
}
host.UseMiddleware<ExceptionMiddleware>();
// Configure the HTTP request pipeline.
if (host.Environment.IsDevelopment())
{
    host.UseSwaggerDocmentation();
}
host.UseStatusCodePagesWithReExecute("/erorr/{0}");
host.UseHttpsRedirection();

host.UseAuthorization();
host.UseStaticFiles();
host.MapControllers();

host.Run();
