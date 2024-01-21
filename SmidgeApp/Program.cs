using Smidge;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddSmidge(builder.Configuration.GetSection("smidge"));

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

app.UseAuthorization();
app.UseSmidge(bundle =>
{
    //bundle.CreateJs("js-bundle", "~/js/site.js", "~/js/site2.js");
    bundle.CreateJs("js-bundle", "~/js/"); 

    bundle.CreateCss("css-bundle", "~/css/site.css", "~/lib/bootstrap/dist/css/bootstrap.css");
});



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
