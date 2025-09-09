var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Middleware 1: Logs all the requests
app.Use(async (context, next) =>
{
    Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");
    await next.Invoke();
});

// Middleware 3: Static files middleware (move this UP before auth)
app.UseStaticFiles(); // serves files from wwwroot

// Middleware 2: Authentication check
app.Use(async (context, next) =>
{
    if (context.Request.Query.TryGetValue("auth", out var authkey) && authkey == "secret")
    {
        await next();
    }
    else
    {
        context.Response.StatusCode = 401; // Unauthorized
        await context.Response.WriteAsync("Unauthorized");
    }
});

// Middleware 4: Exception handling
app.UseExceptionHandler("/error");

app.MapGet("/", () => "Hello World from API ...");

app.Run();
