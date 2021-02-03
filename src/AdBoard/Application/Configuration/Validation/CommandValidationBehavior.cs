using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Configuration.Validation
{
    public class CommandValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly IList<IValidator<TRequest>> validators;

        public CommandValidationBehavior(IList<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var errors = validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();

            if (errors.Any())
            {
                var errorBuilder = new StringBuilder();

                errorBuilder.AppendLine("Invalid command, reason: ");

                foreach (var error in errors)
                {
                    errorBuilder.AppendLine(error.ErrorMessage);
                }

                throw new InvalidCommandException(errorBuilder.ToString(), null);
            }

            return next();
        }
    }
}
