using EmployeeSalaryReport.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Adding Authorization Filter
builder.Services.AddScoped<AuthorizationFilter>();

//Add Caching Filter
builder.Services.AddScoped<ProductCacheResourceFilter>();

//Add Logging Filter
builder.Services.AddScoped<LogFilter>();

//Add Exception Filter
builder.Services.AddScoped<GlobalExceptionFilter>();

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

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
