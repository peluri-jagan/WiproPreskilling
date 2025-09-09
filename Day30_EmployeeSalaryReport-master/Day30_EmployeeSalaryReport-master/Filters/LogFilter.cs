using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace EmployeeSalaryReport.Filters
{
    public class LogFilter : IAsyncActionFilter
    {
        private readonly ILogger<LogFilter> _logger;
        public LogFilter(ILogger<LogFilter> logger) => _logger = logger;

        public async Task OnActionExecutionAsync(ActionExecutingContext ctx, ActionExecutionDelegate next)
        {
            // Simple input guard
            if (ctx.ActionArguments.TryGetValue("id", out var val) &&
                val is int id && id <= 0)
            {
                ctx.Result = new BadRequestObjectResult("Order id must be > 0.");
                return;
            }

            var sw = Stopwatch.StartNew();
            _logger.LogInformation("Action start: {Action}", ctx.ActionDescriptor.DisplayName);
            var executed = await next();
            sw.Stop();
            _logger.LogInformation("Action end: {Action} in {Ms}ms", ctx.ActionDescriptor.DisplayName, sw.ElapsedMilliseconds);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"Action executed: {context.ActionDescriptor.DisplayName}");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"Action executing: {context.ActionDescriptor.DisplayName}");
        }
    }
}