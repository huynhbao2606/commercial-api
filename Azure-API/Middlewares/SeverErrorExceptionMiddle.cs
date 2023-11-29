
using AzureAPI.Exceptions;
using Microsoft.Extensions.Hosting;
using System.Net;
using System.Text.Json;

namespace AzureAPI.Middlewares
{
    public class SeverErrorExceptionMiddle
    {
        private readonly RequestDelegate _next;

        private readonly IHostEnvironment _environment;

        public SeverErrorExceptionMiddle(RequestDelegate next, IHostEnvironment environment)
        {
            _next = next;
            _environment = environment;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                ErrorResponse response = _environment.IsDevelopment() 
                    ? new ErrorResponse((int) HttpStatusCode.InternalServerError, ex.Message + ". StackTrace : " + ex.StackTrace) // toString
                    : new ErrorResponse((int) HttpStatusCode.InternalServerError, ex.Message);


                var option = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase};

                string json = JsonSerializer.Serialize(response, option);  

                await context.Response.WriteAsync(json);

            }
        }
    }
}
