using Hangfire;
using Hangfire.Dashboard;
using Hangfire.MemoryStorage;
using WebScrapperWorker.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddHangfire(c => c.UseMemoryStorage());
builder.Services.AddHangfireServer();
builder.Services.AddScoped<IServiceManagement, ServiceManagement>();

JobStorage.Current = new MemoryStorage();



RecurringJob.AddOrUpdate<IServiceManagement>("GetMessage", x => x.GetMessage(), cronExpression: Cron.Hourly);
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.UseHangfireDashboard("/hangfire", new DashboardOptions
{
    Authorization = new IDashboardAuthorizationFilter[0]
});

app.Run();
