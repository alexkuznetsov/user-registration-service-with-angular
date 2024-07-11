using LoginPage.Application.Common.Messaging;
using LoginPage.Application.Common.Persistance;
using LoginPage.Domain.Locations;

using MediatR;

namespace LoginPage.Application.Provinces.Queries;
public static class ProviceFindOne
{
    public record Query(Guid ProvinceId) : IMessage<Result>;

    public class Result : ResultBase<Result, Province>;

    public class Handler : IRequestHandler<Query, Result>
    {
        private readonly IProvincesRepository _provincesRepository;

        public Handler(IProvincesRepository provincesRepository)
        {
            _provincesRepository = provincesRepository;
        }

        public async Task<Result> Handle(Query request, CancellationToken cancellationToken)
        {
            var entity = await _provincesRepository.FindAsync(ProvinceId.Create(request.ProvinceId), cancellationToken);

            return entity is null
                ? Result.CreateNotFound()
                : Result.Ok(entity);
        }
    }
}
