using System;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using GenTemplate.Application.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace WellsMaster.WebApi.Middlewares
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
                var response = context.Response;
                response.ContentType = MediaTypeNames.Application.Json;
                var modelString = new StringBuilder();

                switch (error)
                {
                    case BasicException.BadRequestException exception:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;

                        modelString.Append(JsonConvert.SerializeObject(exception.Errors));

                        break;

                    case BasicException.UnauthorizedException exception:
                        response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        modelString.Append(JsonConvert.SerializeObject(exception?.Message));

                        break;

                    case BasicException.NotFoundException exception:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        modelString.Append(JsonConvert.SerializeObject(exception?.Message));

                        break;

                    case BasicException.ConflicException exception:
                        response.StatusCode = (int)HttpStatusCode.Conflict;
                        modelString.Append(JsonConvert.SerializeObject(exception?.Message));

                        break;

                    default:  // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        modelString.Append(JsonConvert.SerializeObject(error?.Message));

                        break;
                }

                await response.WriteAsync(modelString.ToString());
            }
        }
    }
}
