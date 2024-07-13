using FluentValidation;

using MediatR;

using UserPortal.Application.Common.Messaging;

namespace UserPortal.Application.Common.PipelineBehaviurs;

public class ValidationMediatorPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : ResponseBase, new()
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationMediatorPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);
            var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));

            var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();
            if (failures.Count != 0)
            {
                var result = new TResponse
                {
                    State = ResultState.Failure
                };

                foreach (var f in failures)
                {
                    result.Failures.Add(new Failure(
                        ErrorCode: f.ErrorCode,
                        ErrorMessage: f.ErrorMessage,
                        PropertyName: f.PropertyName));
                }

                return result;
            }
        }

        return await next();
    }
}
