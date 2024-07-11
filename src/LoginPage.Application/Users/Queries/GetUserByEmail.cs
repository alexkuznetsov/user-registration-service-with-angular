using LoginPage.Application.Common.Messaging;
using LoginPage.Application.Common.Persistance;
using LoginPage.Domain.Users;

using MediatR;

namespace LoginPage.Application.Users.Queries;
public static class GetUserByEmail
{
    public record Query(string Email) : IMessage<Result>;

    public class Result : ResultBase<Result, User>;

    public class Handler : IRequestHandler<Query, Result>
    {
        private readonly IUsersRepository _usersRepository;

        public Handler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<Result> Handle(Query request, CancellationToken cancellationToken)
        {
            var user = await _usersRepository.FindByEmail(request.Email, cancellationToken);

            return user is null
                ? Result.CreateNotFound()
                : Result.Ok(user);
        }
    }
}
