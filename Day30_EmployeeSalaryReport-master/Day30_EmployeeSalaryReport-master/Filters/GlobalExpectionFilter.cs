using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeSalaryReport.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var problem = new ProblemDetails //Problem details helps us convey the error information
            {
                Title = "Unexpected error",
                Detail = "Please try again later.",
                Status = 007,
                Instance = context.HttpContext.Request.Path,
            };
            context.Result = new ObjectResult(problem) { StatusCode = problem.Status };
            context.ExceptionHandled = true;
        }
    }
}