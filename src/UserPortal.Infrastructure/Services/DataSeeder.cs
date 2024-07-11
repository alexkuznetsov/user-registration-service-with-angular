using UserPortal.Application.Common.Persistance;
using UserPortal.Application.Common.Services;
using UserPortal.Domain.Locations;
using UserPortal.Domain.Users;

using Microsoft.AspNetCore.Identity;

namespace UserPortal.Infrastructure.Services;

internal class DataSeeder
{
    private readonly ICountriesRepository _countriesRepository;
    private readonly IProvincesRepository _provincesRepository;
    private readonly IUsersRepository _usersRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher<User> _passwordHasher;

    public DataSeeder(
        ICountriesRepository countriesRepository,
        IProvincesRepository provincesRepository,
        IUsersRepository usersRepository,
        IUnitOfWork unitOfWork,
        IPasswordHasher<User> passwordHasher)
    {
        _countriesRepository = countriesRepository;
        _provincesRepository = provincesRepository;
        _usersRepository = usersRepository;
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
    }

    internal void SeedData()
    {
        var countryKz = Country.Create("Kazakhstan");
        var countryUsa = Country.Create("USA");

        var provinceKz1 = Province.Create("East Kazakstan", countryKz);
        var provinceKz2 = Province.Create("South Kazakhstan", countryKz);

        if (!_countriesRepository.GetAll().Any())
        {


            var provinceUsa1 = Province.Create("California", countryUsa);
            var provinceUsa2 = Province.Create("Texas", countryUsa);

            _countriesRepository.Add(countryKz);
            _countriesRepository.Add(countryUsa);

            _provincesRepository.Add(provinceKz1);
            _provincesRepository.Add(provinceKz2);
            _provincesRepository.Add(provinceUsa1);
            _provincesRepository.Add(provinceUsa2);
        }


        if (!_usersRepository.GetAll().Any())
        {
            var user = User.Create("admin@local", "", provinceKz1);
            var hash = _passwordHasher.HashPassword(user, "1qaz!QAZ");
            user.SetPassword(hash);

            _usersRepository.Add(user);
        }

        _unitOfWork.Save();
    }
}
