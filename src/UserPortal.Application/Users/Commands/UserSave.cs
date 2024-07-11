using UserPortal.Application.Common.Messaging;
using UserPortal.Application.Common.Persistance;
using UserPortal.Application.Common.Services;
using UserPortal.Domain.Users;

using MediatR;

namespace UserPortal.Application.Users.Commands;
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
            IUnitOfWorkTransaction? tx = null;

            try
            {
                tx = await _unitOfWork.BeginTransactionAsync(cancellationToken);
                _usersRepository.Add(request.User);
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
