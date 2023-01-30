using BlazorAbbPoc.Server.Services;
using Microsoft.EntityFrameworkCore;
using BlazorAbbPoc.Server.Models;
using Microsoft.Extensions.DependencyInjection;
using BlazorAbbPoc.Server.Workers;
using Microsoft.AspNetCore.Authentication.JwtBearer;

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
builder.Services.AddHostedService<RabbitMqWorker>();

builder.Services.AddDbContext<ApiDbContext>(options => 
    options.UseNpgsql("host=postgres;port=5432;database=blogdb;username=bloguser;password=bloguser", o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery))
    );

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.Authority = builder.Configuration["Auth0:Authority"];
    options.Audience = builder.Configuration["Auth0:ApiIdentifier"];
});

var app = builder.Build();

var ssf = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = ssf.CreateScope())
{
    ApiDbContext dbContext = scope.ServiceProvider.GetService<ApiDbContext>();
    dbContext.Database.Migrate();
    List<Cabinet> cabinets = dbContext.Cabinets.ToList();
    foreach (var c in cabinets)
    {
        var temp = c;
        string s = c.Name;
        while (temp.ParentCabinet is not null)
        {
            s += $"/{temp.ParentCabinet.Name}";
            temp = temp.ParentCabinet;
        }
        Console.WriteLine(s);
    }
}

IHierarchicalNameService hierarchicalNameService = app.Services.GetRequiredService<IHierarchicalNameService>();
hierarchicalNameService.Initialize();
IPlcMsgDispatcher plcMsgDispatcher = app.Services.GetRequiredService<IPlcMsgDispatcher>();
plcMsgDispatcher.Initialize();

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

app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
