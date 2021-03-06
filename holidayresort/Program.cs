using Microsoft.EntityFrameworkCore;
using Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")  
    ));
builder.Services.AddTransient<DataHandler, DataHandler>();
builder.Services.AddSingleton<Utils, Utils>();
builder.Services.AddMvc().AddNToastNotifyToastr();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseNToastNotify();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=LandingPage}/{action=Index}/{id?}");

app.Run();
