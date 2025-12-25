using Hangfire;
using HangfireBasicAuthenticationFilter;
using Serilog;
using SurveyBasket.Application.Abstractions.Repositories.Notification;
using SurveyBasket.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddDependencies(builder.Configuration);
// -- Logging Configuration - Using Serilog
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
    DashboardTitle = "Survey Basket Dashboard",

    // IsReadOnlyFunc = (DashboardContext context) => true   //-- Make dashboard read-only for all users (Limit Actions)

});
var scopFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using var scope= scopFactory.CreateScope();
var notificationService =  scope.ServiceProvider.GetRequiredService<INotificationService>();
 
RecurringJob.AddOrUpdate("SendNewNotificationAsync", () => notificationService.SendNewNotificationAsync(null), Cron.Daily /*"0 9 1 * *"*/);

app.UseCors();

app.UseAuthorization();


app.MapControllers();

app.UseExceptionHandler();

app.Run();
