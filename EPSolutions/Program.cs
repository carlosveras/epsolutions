using EPSolutions.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string? connectionString = builder.Configuration.GetConnectionString("Default");
ServerVersion serverVersion = ServerVersion.AutoDetect(connectionString);

builder.Services.AddDbContext<EPSolutionsContext>(options => options.UseMySql(connectionString, serverVersion));

builder.Services.Configure<MvcViewOptions>(options =>
    options.HtmlHelperOptions.CheckBoxHiddenInputRenderMode =
        CheckBoxHiddenInputRenderMode.None);

builder.Services.AddControllersWithViews();

var app = builder.Build();

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
    pattern: "{controller=ItensRomaneio}/{action=Index}/{id?}");

//app.UseEndpoints(endpoints =>
//{
//    //endpoints.MapControllerRoute(
//    //    name: "default",
//    //    pattern: "{controller=Home}/{action=Index}/{id?}");

//    endpoints.MapControllerRoute(
//        name: "Romaneio",
//        pattern: "Romaneio/Buscar",
//        defaults: new { controller = "Romaneio", action = "Buscar" });

//});

app.Run();
