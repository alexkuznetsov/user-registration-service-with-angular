using LoginPage.Application.Common.Messaging;
using LoginPage.Application.Common.Persistance;
using LoginPage.Domain.Locations;

using MediatR;

namespace LoginPage.Application.Provinces.Queries;
public static class GetProviceList
{
    public record Query(Guid countryId) : IMessage<Result>;

    public class Result : ResultBase<Result, ProvinceModel[]>;

    public record ProvinceModel(Guid Id, string Name);

    public class Handler : IRequestHandler<Query, Result>
    {
        private readonly IProvincesRepository _provincesRespository;

        public Handler(IProvincesRepository provincesRespository)
        {
            _provincesRespository = provincesRespository;
        }

        public Task<Result> Handle(Query request, CancellationToken cancellationToken)
        {
            var entities = _provincesRespository.GetAllByCountry(CountryId.Create(request.countryId))
                .ProjectToProviceModels();

            var models = entities.ToArray();

            return Task.FromResult(Result.Ok(models));
        }
    }

    internal static IQueryable<ProvinceModel> ProjectToProviceModels(this IQueryable<Province> q)
        => q.Select(e => new ProvinceModel(e.Id.Value, e.Name));
}
