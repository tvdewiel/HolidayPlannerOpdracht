using HolidayPlannerBL.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HolidayPlannerREST.Middleware
{
    public class ResponseServiceMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger requestLogger;
        private readonly ILogger domainExceptionLogger;
        private readonly ILogger infrastructureExceptionLogger;
        private string requestBody;

        public ResponseServiceMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            this.next = next;
            requestLogger = loggerFactory.CreateLogger("RequestLogging");
            domainExceptionLogger = loggerFactory.CreateLogger("DomainExceptionLogging");
            infrastructureExceptionLogger = loggerFactory.CreateLogger("InfrastructureExceptionLogging");
        }
        public async Task Invoke(HttpContext context)
        {            
            try
            {
                context.Request.EnableBuffering();
                // Read the request body as a string
                
                using (StreamReader reader = new StreamReader(context.Request.Body, Encoding.UTF8, true, 1024, true))
                {
                    requestBody = await reader.ReadToEndAsync();
                    requestBody=requestBody.Replace("\n",string.Empty).Replace("\t",string.Empty);
                    context.Request.Body.Seek(0, SeekOrigin.Begin); // Reset the position so other middleware can read the body
                }
                await next(context);               
            }
            catch(DomainModelException ex) 
            {
                await ProcessDomainError(ex,context);
            }
            catch(InfrastructureException ex) 
            {                
                await ProcessInfrastructureError(ex, context);
            }
            catch(ServiceException ex)
            {
                await ProcessServiceError(ex,context);
            }
            catch(Exception ex)
            {
                //TODO process ex
            }
            finally
            {
                requestLogger.LogInformation(
                    "Request {method} {url} => {statusCode}",
                    context.Request?.Method,
                    context.Request?.Path.Value,
                    context.Response?.StatusCode);
            }
        }
        private async Task ProcessServiceError(ServiceException ex, HttpContext context)
        {
            domainExceptionLogger.LogError("ServiceException"
                 + "\n\t[" + string.Join('|', GetExceptionMessages(ex)) + "]"
                 + "\n\t[" + string.Join('|', ex.Sources) + "]"
                 + "\n\t[" + ex.Error.ToString() + "]"
                 + "\n\t[" + context.Request?.Path.Value + "]"
                 + "\n\t[" + context.Request?.Method + "]"
                 + "\n\t[" + requestBody + "]"
                 );

            var errorResponse = new ServiceErrorResponse(400, "Service Error", ex.Error, context.Request?.Path.Value, context.Request?.Method,requestBody);
            // Serialize the error response to JSON
            var json = JsonConvert.SerializeObject(errorResponse);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = errorResponse.StatusCode;
            await context.Response.WriteAsync(json);
        }
        private async Task ProcessDomainError(DomainModelException ex, HttpContext context)
        {
            domainExceptionLogger.LogError("DomainException" 
                 + "\n\t["+string.Join('|', GetExceptionMessages(ex))+"]"
                 + "\n\t["+string.Join('|',ex.Sources)+"]"
                 + "\n\t["+ex.Error.ToString()+"]"
                 );
            var errorResponse = new DomainErrorResponse(400, "Domain Error", ex.Error);
            // Serialize the error response to JSON
            var json = JsonConvert.SerializeObject(errorResponse);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = errorResponse.StatusCode;
            await context.Response.WriteAsync(json);
        }
        private async Task ProcessInfrastructureError(InfrastructureException ex, HttpContext context)
        {
            infrastructureExceptionLogger.LogError("Infrastructure Error"
                + "\n\t[" + string.Join('|', GetExceptionMessages(ex)) + "]"
                + "\n\t[" + string.Join('|', ex.Sources) + "]");
            var errorResponse = new InfrastructureErrorResponse(500, "Infrastructure Error");
            // Serialize the error response to JSON
            var json = JsonConvert.SerializeObject(errorResponse);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = errorResponse.StatusCode;
            await context.Response.WriteAsync(json);
        }
        private List<string> GetExceptionMessages(Exception exception)
        {
            var messages = new List<string>();

            while (exception != null)
            {
                messages.Add(exception.Message);
                exception = exception.InnerException;
            }
            return messages;
        }
    }
}
