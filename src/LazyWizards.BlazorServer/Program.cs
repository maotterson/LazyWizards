using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using LazyWizards.BlazorServer.Data;
using Microsoft.AspNetCore.ResponseCompression;
using LazyWizards.BlazorServer;
using LazyWizards.BlazorServer.Utils.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add response compression for SignalR
builder.Services.AddResponseCompression(opts =>
{
   opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
         new[] { "application/octet-stream" });
});

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Add services to the container.
builder.Services.AddSingleton<WeatherForecastService>(); // can delete eventually
builder.Services.AddServices();

var app = builder.Build();

app.UseResponseCompression();
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

app.MapBlazorHub();
app.MapHub<StatusHub>("/statushub");
app.MapFallbackToPage("/_Host");

app.Run();
