namespace LoginPage.Application.Common.Messaging;

public interface IMessage : MediatR.IRequest
{
}

public interface IMessage<T> : MediatR.IRequest<T>
{
}
