using HelpingHands.Models;
using HelpingHands.Services;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(60); // Customize as needed
    options.Cookie.IsEssential = true;
});

// Register in-memory lists as services
builder.Services.AddSingleton<List<Volunteer>>();
builder.Services.AddSingleton<List<Programme>>();
builder.Services.AddSingleton<List<Resource>>();
builder.Services.AddSingleton<List<Event>>();

// Register your services
builder.Services.AddSingleton<VolunteerService>();
builder.Services.AddSingleton<ProgrammeService>();
builder.Services.AddSingleton<ResourceService>();
builder.Services.AddSingleton<EventService>();

var app = builder.Build();

// Initialize sample data at startup
AddSampleData(app.Services);

void AddSampleData(IServiceProvider services)
{
    var volunteerService = services.GetRequiredService<VolunteerService>();
    var programmeService = services.GetRequiredService<ProgrammeService>();
    var eventService = services.GetRequiredService<EventService>();
    var resourceService = services.GetRequiredService<ResourceService>();

    volunteerService.AddSampleData();
    programmeService.AddSampleData();
    eventService.AddSampleData();
    resourceService.AddSampleData();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
