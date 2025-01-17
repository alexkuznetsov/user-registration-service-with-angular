﻿using UserPortal.Application.Common.Messaging;
using UserPortal.Application.Common.Persistance;
using UserPortal.Domain.Users;

using MediatR;

namespace UserPortal.Application.Users.Queries;
public static class UserByEmail
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
