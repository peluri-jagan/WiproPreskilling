//Here we will define event constraints class
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;

public class EvenConstraints : IRouteConstraint
{
    public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
    {
        if (httpContext == null || route == null || values == null)
        {
            return false;
        }

        // if (values.TryGetValue(routeKey, out var value) && value is int intValue)
        // {
        //     // Check if the event name meets your custom constraints
        //     return intValue % 2 == 0;
        // }

        if(int.TryParse(values[routeKey]?.ToString(), out var intValue))
        {
            // Example constraint: Check if the event ID is greater than 0
            return intValue % 2 == 0;
        }

        return false;
    }
}