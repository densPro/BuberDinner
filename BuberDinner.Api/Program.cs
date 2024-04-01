using BuberDinner.Application;
using BuberDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
  // Add services to the container.
  builder.Services.AddApplication()
                  .AddInfrastructure();
  // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
  builder.Services.AddEndpointsApiExplorer();
  builder.Services.AddSwaggerGen();
  builder.Services.AddControllers();
}

var app = builder.Build();
{
  // Configure the HTTP request pipeline.
  if (app.Environment.IsDevelopment())
  {
    app.UseSwagger();
    app.UseSwaggerUI();
  }
  app.UseHttpsRedirection();
  // Map the controller endpoints
  app.MapControllers();
  app.Run();
}


