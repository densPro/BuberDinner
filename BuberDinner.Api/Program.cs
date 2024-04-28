using BuberDinner.Api.Common.Errors;
using BuberDinner.Application;
using BuberDinner.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
  // Add services to the container.
  builder.Services.AddApplication()
                  .AddInfrastructure(builder.Configuration);
  // builder.Services.AddSwaggerGen();
  builder.Services.AddControllers();
  builder.Services.AddSingleton<ProblemDetailsFactory, BubberDinnerProblemDetailsFactory>();
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


