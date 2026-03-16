using Test.Subscriber.Application.Extensions;
using Test.Subscriber.Infraestructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSubscriberInfrastructure(builder.Configuration);
builder.Services.AddSubscriberApplication();
// Add services to the container.

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

app.AddSubscriberInfrastructure(app.Services);

app.Run();
