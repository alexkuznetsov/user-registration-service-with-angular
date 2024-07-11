using UserPortal.Application.Common.Messaging;

using MediatR;

namespace UserPortal.Application;

public class Dispatcher
{
    private readonly IMediator _mediator;

    public Dispatcher(IMediator mediator)
    {
        _mediator = mediator;
    }

    public Task<T> SendAsync<T>(IMessage<T> message, CancellationToken cancellationToken = default)
    {
        return _mediator.Send(message, cancellationToken);
    }

    public Task SendAsync(IMessage message, CancellationToken cancellationToken = default)
    {
        return _mediator.Send(message, cancellationToken);
    }
}
