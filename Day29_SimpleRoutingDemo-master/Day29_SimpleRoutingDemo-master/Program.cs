var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Register custom route constraints
builder.Services.Configure<RouteOptions>(options =>
{
    options.ConstraintMap.Add("even", typeof(EvenConstraints));
    options.ConstraintMap.Add("odd", typeof(OddConstraints));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

//Adding Custom routing endpoints
app.MapControllerRoute(
    name: "even",
    pattern: "number/{id:even}",
    defaults: new { controller = "Home", action = "EvenOnly" });

app.MapControllerRoute(
    name: "odd",
    pattern: "number/{id:odd}",
    defaults: new { controller = "Home", action = "OddOnly" });

app.MapControllerRoute(
    name: "any",
    pattern: "number/{id:int}",
    defaults: new { controller = "Home", action = "AnyId" });

app.MapControllerRoute(
    name: "special",
    pattern: "number/special",
    defaults: new { controller = "Home", action = "SpecialOnly" });

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
