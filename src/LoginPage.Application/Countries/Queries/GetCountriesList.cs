using LoginPage.Application.Common.Messaging;
using LoginPage.Application.Common.Persistance;
using LoginPage.Domain.Locations;

using MediatR;

namespace LoginPage.Application.Countries.Queries;

public static class GetCountriesList
{
    public record Query : IMessage<Result>;

    public class Result : ResultBase<Result, CountryModel[]>;

    public record CountryModel(Guid Id, string Name);

    public class Handler : IRequestHandler<Query, Result>
    {
        private readonly ICountriesRepository _countriesRespository;

        public Handler(ICountriesRepository countriesRespository)
        {
            _countriesRespository = countriesRespository;
        }

        public Task<Result> Handle(Query request, CancellationToken cancellationToken)
        {
            var countries = _countriesRespository.GetAll()
                .ProjectToCountryModel()
                .ToArray();

            return Task.FromResult(Result.Ok(countries));
        }
    }

    internal static IQueryable<CountryModel> ProjectToCountryModel(this IQueryable<Country> s)
        => s.Select(e => new CountryModel(e.Id.Value, e.Name));
}
