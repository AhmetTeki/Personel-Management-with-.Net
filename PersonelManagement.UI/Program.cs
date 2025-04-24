using PersonelManagement.Persistance;
using PersonelManagement.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddPersistanceServices(builder.Configuration);

builder.Services.AddApplicationServices();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();



app.MapControllerRoute(name: "default", pattern: "{Controller=Account}/{Action=Login}/{id?}");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});


app.Run();
