// using BuberDinner.Api.Filters;
// using BuberDinner.Api.Middleware;
using BuberDinner.Api.Errors;
using BuberDinner.Application;
using BuberDinner.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
  // Add services to the container.
  builder.Services.AddApplication()
                  .AddInfrastructure(builder.Configuration);
  // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
  builder.Services.AddEndpointsApiExplorer();
  // builder.Services.AddSwaggerGen();
  builder.Services.AddControllers();
  builder.Services.AddSingleton<ProblemDetailsFactory, BubberDinnerProblemDetailsFactory>();
  // builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
}

var app = builder.Build();
{
  // Configure the HTTP request pipeline.
  // if (app.Environment.IsDevelopment())
  // {
  //   app.UseSwagger();
  //   app.UseSwaggerUI();
  // }
  // app.UseMiddleware<ErrorHandlingMiddleware>();
  app.UseHttpsRedirection();
  app.UseExceptionHandler("/error");

  // Map the controller endpoints
  app.MapControllers();
  app.Run();
}


