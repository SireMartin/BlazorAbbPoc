using BlazorAbbPoc.Server.Services;
using Microsoft.EntityFrameworkCore;
using BlazorAbbPoc.Server.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(configure =>
{
    configure.JsonSerializerOptions.IncludeFields = true;
});
builder.Services.AddRazorPages();

builder.Services.AddSingleton<IActualValueService, ActualValueService>();
builder.Services.AddSingleton<IHierarchicalNameService, HierarchicalNameService>();
builder.Services.AddSingleton<IPlcMsgDispatcher, PlcMsgDispatcher>();

builder.Services.AddDbContext<ApiDbContext>(options => options.UseNpgsql("host=localhost;port=5432;database=blogdb;username=bloguser;password=bloguser"));

var app = builder.Build();

IHierarchicalNameService hierarchicalNameService = app.Services.GetRequiredService<IHierarchicalNameService>();
await hierarchicalNameService.Initialize();
IPlcMsgDispatcher plcMsgDispatcher = app.Services.GetRequiredService<IPlcMsgDispatcher>();
await plcMsgDispatcher.Initialize();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
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
