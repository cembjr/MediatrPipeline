using CB.MediatrPipeline.Exceptions;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CB.MediatrPipeline.Setup
{
    public static class MediatrSetup
    {
        public static IServiceCollection AddMediatrSetup(this IServiceCollection services)
        {
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationCommandPipelineBehavior<,>));
            services.AddMediatR(typeof(Startup));
            return services;
        }
    }

    public class ValidationCommandPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationCommandPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var failures = _validators.Select(v => v.Validate(request))
                                      .SelectMany(result => result.Errors)
                                      .Where(f => f is not null)
                                      .ToList();

            if(failures.Any())
                throw new CommandValidationException($"Erro na validação do Comando {typeof(TRequest).Name}", failures);
            
            return await next();
        }
    }
}
