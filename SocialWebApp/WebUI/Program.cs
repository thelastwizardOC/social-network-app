using System.Text.Json;
using System.Text.Json.Serialization;
using Application;
using Infrastructure;
using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using WebUI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

<<<<<<< HEAD
builder.Services.AddControllers().AddNewtonsoftJson(option =>
{
  option.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
  option.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
  option.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
=======
builder.Services.AddControllers().AddNewtonsoftJson(option => {
    option.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    option.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    option.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
>>>>>>> ee12fbc (feat: create get photos api + photo tab UI)
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
<<<<<<< HEAD
  app.UseSwagger();
  app.UseSwaggerUI();
}
app.UseCors(policy => policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthentication();

=======
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(policy => policy.AllowAnyHeader().AllowAnyOrigin());

app.UseHttpsRedirection();
app.UseAuthentication();
>>>>>>> ee12fbc (feat: create get photos api + photo tab UI)
app.UseAuthorization();

app.MapControllers();

app.Run();
