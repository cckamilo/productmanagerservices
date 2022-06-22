using System;
using Microsoft.AspNetCore.Builder;
using Services.ProductsApi.Middlewares;

namespace Services.ProductsApi.Extensions
{
    public static class AppExtensions
    {
        public static void UseErrorHandlerMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
