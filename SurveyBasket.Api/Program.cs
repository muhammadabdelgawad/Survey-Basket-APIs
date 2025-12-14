using Serilog;
using SurveyBasket.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDependencies(builder.Configuration);

builder.Host.UseSerilog((context,configuration) => 
{
    configuration.MinimumLevel.Information()
                 .WriteTo.Console();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();


app.MapControllers();

app.UseExceptionHandler();

app.Run();
