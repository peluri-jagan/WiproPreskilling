using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;

namespace EmployeeSalaryReport.Filters
{
    public class ProductCacheResourceFilter : IResourceFilter
    {
        private readonly IMemoryCache _cache;
        public ProductCacheResourceFilter(IMemoryCache cache) => _cache = cache;
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            // Caching
            var key = context.HttpContext.Request.Path.ToString();

            // Storing Data before the action executes
            if (_cache.TryGetValue<string>(key, out var cached))
                context.Result = new ContentResult { Content = cached, ContentType = "text/plain" };
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            var key = context.HttpContext.Request.Path.ToString();
            if (context.Result is ContentResult cr)
                _cache.Set(key, cr.Content!, TimeSpan.FromSeconds(20));
                //Here we are displaying the cached content with a 20 seconds expiration
        }
    }
}