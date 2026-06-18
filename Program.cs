using dentist.api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{ 
    app.UseSwagger();

    app.UseSwaggerUI(c =>
                {
                    c.RoutePrefix = "api/v1";
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dentist API V1");
                });
}

app.UseHttpsRedirection();



app.MapControllers();

app.Run();
