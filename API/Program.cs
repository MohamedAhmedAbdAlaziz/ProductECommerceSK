using Infrastructure.Data;
using Core.Interfaces;

using Infrastrucrture.Data;
using Microsoft.EntityFrameworkCore;
using API.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>),(typeof(GenericRepository<>)));

builder.Services.AddAutoMapper(typeof(MappingProfiles));

builder.Services.AddControllers();
builder.Services.AddDbContext<StoreContext>(x=> x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));





// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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




// Configure the HTTP request pipeline.
if (host.Environment.IsDevelopment())
{
    host.UseSwagger();
    host.UseSwaggerUI();
}

host.UseHttpsRedirection();

host.UseAuthorization();
host.UseStaticFiles();
host.MapControllers();

host.Run();
