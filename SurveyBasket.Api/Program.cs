using Hangfire;
using HangfireBasicAuthenticationFilter;
using Serilog;
using SurveyBasket.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDependencies(builder.Configuration);


builder.Host.UseSerilog((context,configuration) => 
{
    configuration.ReadFrom.Configuration(context.Configuration);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseHangfireDashboard("/jobs", new DashboardOptions
{
    Authorization =
    [
        new HangfireCustomBasicAuthenticationFilter
        {
            User = app.Configuration.GetValue<string>("HangfireSettings:UserName"),
            Pass = app.Configuration.GetValue<string>("HangfireSettings:Password")
        }
    ],
    DashboardTitle = "Survey Basket Dashboard "
});

app.UseCors();

app.UseAuthorization();


app.MapControllers();

app.UseExceptionHandler();

app.Run();
