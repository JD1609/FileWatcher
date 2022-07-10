global using FileWatcher.Shared.Data;
global using FileWatcher.Server.Services;
global using FileWatcher.Shared;
using FileWatcher.Server;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

    // Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

    // FileWatcher
var changes = new List<ChangeData>();
var fileWatcher = FileWatcherHandler.CreateFileTracker(changes);

builder.Services.AddSingleton(sp => fileWatcher);
builder.Services.AddSingleton(sp => changes);
builder.Services.AddScoped<IFileTrackerService, FileTrackerService>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Swagger
    app.UseSwaggerUI();
    app.UseSwagger();
    
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
