using MediatR;

using Microsoft.AspNetCore.Identity;

using UserPortal.Application.Common.Messaging;
using UserPortal.Application.Common.Persistance;
using UserPortal.Application.Common.Services;
using UserPortal.Application.Errors;
using UserPortal.Domain.Locations;
using UserPortal.Domain.Users;

namespace UserPortal.Application.Users.Commands;
public static partial class UserSave
{
    public record Command(string Login, string Password,
        string Password2, bool? AgreeToWork, Guid? ProvinceId) : IMessage<Result>;

    public class Result : ResultBase<Result>;

    public class Handler : IRequestHandler<Command, Result>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IProvincesRepository _provincesRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUsersRepository usersRepository,
            IProvincesRepository provincesRepository,
             IPasswordHasher<User> passwordHasher,
            IUnitOfWork unitOfWork)
        {
            _usersRepository = usersRepository;
            _provincesRepository = provincesRepository;
            _passwordHasher = passwordHasher;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
        {
            IUnitOfWorkTransaction? tx = null;

            try
            {
                var u = await _usersRepository.FindByEmail(request.Login, cancellationToken);

                if (u is not null)
                {
                    return Result.CreateFailure(UserErrors.AlreadyExists);
                }

                var province = await _provincesRepository.FindAsync(ProvinceId
                        .Create(request.ProvinceId.GetValueOrDefault()), cancellationToken);

                if (province is null)
                {
                    return Result.CreateFailure(ProvinceErrors.NotFound);
                }

                tx = await _unitOfWork.BeginTransactionAsync(cancellationToken);


                var user = User.Create(request.Login, "", province);
                var passwordHash = _passwordHasher.HashPassword(user, request.Password);

                user.SetPassword(passwordHash);

                _usersRepository.Add(user);

                await _unitOfWork.SaveAsync(cancellationToken);
                await tx.CommitAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                if (tx != null)
                    await tx.RoolbackAsync(cancellationToken);
                return Result.CreateFailure(new Failure("500", ex.Message));
            }
            finally
            {
                tx?.Dispose();
            }

            return Result.Ok();
        }
    }
}
