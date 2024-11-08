using Epic.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace API_Epic.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                await HandleExceptionAsync(context, error);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception error)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            var response = new Dictionary<string, string>
            {
                { "error", error.Message }
            };

            // Determinar el tipo de excepción y establecer el código de estado y el mensaje
            switch (error)
            {
                case ArgumentException:
                    statusCode = HttpStatusCode.BadRequest;
                    break;
                case UnauthorizedAccessException:
                    statusCode = HttpStatusCode.Unauthorized;
                    break;
                case KeyNotFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    break;
                case BadRequestException: 
                    statusCode = HttpStatusCode.BadRequest;
                    break;
                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    break;
            }

            // Establecer el código de estado en la respuesta
            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";


            // Serializar la respuesta a JSON
            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}