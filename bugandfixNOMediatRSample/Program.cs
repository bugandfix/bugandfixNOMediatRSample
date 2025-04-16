using bugandfixNOMediatRSample.Abstractions;
using bugandfixNOMediatRSample.Data;
using bugandfixNOMediatRSample.DTOs;
using bugandfixNOMediatRSample.Implementation;
using bugandfixNOMediatRSample.Implementation.CommandHandlers;
using bugandfixNOMediatRSample.Implementation.Commands;
using bugandfixNOMediatRSample.Implementation.Query;
using bugandfixNOMediatRSample.Implementation.QueryHandlers;
using bugandfixNOMediatRSample.LoggingBehavior;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("FakeAppDb"));

builder.Services.AddScoped<ICommandHandler<CreateProductCommand, ProductDto>, CreateProductHandler>();
builder.Services.AddScoped<IQueryHandler<GetProductByIdQuery, ProductDto?>, GetProductByIdHandler>();



//builder.Services.AddScoped<Mediator>(); // Direct injection, no interface
builder.Services.AddScoped<IMediator, Mediator>();



// Register pipeline behaviors
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));



builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
