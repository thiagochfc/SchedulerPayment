using Microsoft.Extensions.Caching.Memory;
using SchedulerPayment.Payment.Domain;
using SchedulerPayment.Payment.UseCases.Create;
using SchedulerPayment.Payment.UseCases.Pay;
using SchedulerPayment.Payment.UseCases.Query;
using SchedulerPayment.WebApi.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddSingleton<IMemoryCache>(provider => new MemoryCache(new MemoryCacheOptions()))
    .AddSingleton<ISchedulingStore, InMemorySchedulingStore>()
    .AddSingleton<ICreateUseCase, CreateUseCase>()
    .AddSingleton<IQueryUseCase, QueryUseCase>()
    .AddSingleton<IPayUseCase, PayUseCase>();

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
