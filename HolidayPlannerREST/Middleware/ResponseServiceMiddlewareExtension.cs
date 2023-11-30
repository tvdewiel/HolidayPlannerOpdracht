using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayPlannerREST.Middleware
{
    public static class ResponseServiceMiddlewareExtension
    {
        public static IApplicationBuilder UseLogURLMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ResponseServiceMiddleware>();
        }
    }
}
