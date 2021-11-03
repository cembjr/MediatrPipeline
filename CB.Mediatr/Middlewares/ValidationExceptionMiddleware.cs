using CB.MediatrPipeline.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;
using System.Threading.Tasks;

namespace CB.MediatrPipeline.Middlewares
{
    public class ValidationExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (CommandValidationException ex)
            {
                var response = new 
                {
                    Sucesso = false,
                    Mensagem = ex.Mensagem,
                    Erros = ex.Erros
                };

                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                await httpContext.Response.WriteAsJsonAsync(response);
            }

            catch (Exception)
            {
                var response = new 
                {
                    Sucesso = false,
                    Mensagem = "Ocorreu um erro ao executar a operação"
                };

                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                await httpContext.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
