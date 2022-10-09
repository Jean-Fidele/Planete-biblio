using Hangfire;
using Hangfire.Storage.SQLite;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using planete_biblio.Data;
using planete_biblio.Entities;
using planete_biblio.IntefaceMethode;
using planete_biblio.Job;
using planete_biblio.Middle;
using planete_biblio.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add MVC to the container.
builder.Services.AddControllersWithViews();

// Add Context to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString)
           .LogTo(Console.WriteLine, LogLevel.Information)
);

// Add Hangfire to the container.
builder.Services.AddHangfire((provider, configuration) => configuration
              .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
              .UseSimpleAssemblyNameTypeSerializer()
              .UseRecommendedSerializerSettings()
              .UseSQLiteStorage("./Hangfire.db")
              );

GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute { Attempts = 0 });

builder.Services.AddHangfireServer();

// Add DatabaseDeveloper Exception to the container.
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add Identity to the container.
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>();

// Add MediatR to the Assembly containg autor.
builder.Services.AddMediatR(typeof(Auteur));

// Add AddAutoMapper to the container.
builder.Services.AddAutoMapper(config =>
{   
    config.AllowNullCollections = true;
});

// Add Cookies Configuration to the container.
builder.Services.ConfigureApplicationCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
    options.SlidingExpiration = true;
});

// Injection de dependance :  transcient + scoped + singletaon
builder.Services.AddScoped<Fidele, Denis>();
builder.Services.AddConfigGroup(builder.Configuration)
                .AddMyDependencyGroup();

builder.Services.Configure<MyOptions>(options =>
{
    options.opt1 = 1;
    options.opt2 = 2;
});

// Create the service 
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseHangfireDashboard();
app.UseRequestCulture();
app.UseRequestDenis();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

ExecJobs.Run();

app.Run();
