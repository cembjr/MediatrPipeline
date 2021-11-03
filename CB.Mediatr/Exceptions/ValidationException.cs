using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CB.MediatrPipeline.Exceptions
{
    public class CommandValidationException : Exception
    {
        public string Mensagem { get; init; }
        public IEnumerable<string> Erros { get; init; }

        public CommandValidationException(string erro, IEnumerable<ValidationFailure> failures)
        {
            Mensagem = erro;
            Erros = failures.Select(s => $"{s.PropertyName}: {s.ErrorMessage}");
        }
    }
}
