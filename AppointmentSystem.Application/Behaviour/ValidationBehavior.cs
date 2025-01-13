using AppointmentSystem.Application.Exceptions;
using FluentValidation;
using MediatR;

namespace AppointmentSystem.Application.Behaviour
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
     where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any())
                return await next();

            var context = new ValidationContext<TRequest>(request);

            var errorDictionary = (await Task.WhenAll(
                _validators.Select(v => v.ValidateAsync(context, cancellationToken))
            ))
            .SelectMany(result => result.Errors)
            .Where(error => error != null)
            .GroupBy(
                error => error.PropertyName.Substring(error.PropertyName.IndexOf('.') + 1),
                error => error.ErrorMessage,
                (propertyName, errorMessages) => new
                {
                    Key = propertyName,
                    Values = errorMessages.Distinct().ToArray()
                }
            )
            .ToDictionary(x => x.Key, x => x.Values);

            if (errorDictionary.Any())
                throw new ValidationAppException(errorDictionary);

            return await next();
        }
    }
}
