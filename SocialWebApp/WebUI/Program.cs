using Application;
using Infrastructure;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers().AddNewtonsoftJson(option =>
{
  option.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
  option.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
  option.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
});


var app = builder.Build();

// Configure the HTTP request pipeline.

  app.UseSwagger();
  app.UseSwaggerUI();

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
