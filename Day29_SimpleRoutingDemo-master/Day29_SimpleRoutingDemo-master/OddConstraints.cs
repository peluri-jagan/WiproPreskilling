using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;

public class OddConstraints : IRouteConstraint
{
    public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
    {
        if (values.TryGetValue(routeKey, out var value) && 
            int.TryParse(value?.ToString(), out var id))
        {
            return id % 2 != 0; // only odd numbers allowed
        }

        return false;
    }
}
