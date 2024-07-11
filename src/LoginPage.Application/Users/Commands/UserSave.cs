using LoginPage.Application.Common.Messaging;
using LoginPage.Application.Common.Persistance;
using LoginPage.Domain.Users;

using MediatR;

namespace LoginPage.Application.Users.Commands;
public static class UserSave
{
    public record Command(User User) : IMessage<Result>;

    public class Result : ResultBase<Result>;

    public class Handler : IRequestHandler<Command, Result>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUsersRepository usersRepository, IUnitOfWork unitOfWork)
        {
            _usersRepository = usersRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
        {
            _usersRepository.Add(request.User);
            await _unitOfWork.CommitAsync(cancellationToken);

            return Result.Ok();
        }
    }
