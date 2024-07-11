using LoginPage.Domain.Locations;
using LoginPage.Domain.Users;
using LoginPage.Infrastructure.Persistence;

using Microsoft.AspNetCore.Identity;

namespace LoginPage.Infrastructure.Services;

internal class DataSeeder
{
    private readonly LoginPageDbContext _ctx;
    private readonly IPasswordHasher<User> _passwordHasher;

    public DataSeeder(LoginPageDbContext ctx, IPasswordHasher<User> passwordHasher)
    {
        _ctx = ctx;
        _passwordHasher = passwordHasher;
    }

    internal void SeedData()
    {
        if (!_ctx.Countries.Any())
        {
            var countryKz = Country.Create("Kazakhstan");
            var countryUsa = Country.Create("USA");

            var provinceKz1 = Province.Create("East Kazakstan", countryKz);
            var provinceKz2 = Province.Create("South Kazakhstan", countryKz);

            var provinceUsa1 = Province.Create("California", countryUsa);
            var provinceUsa2 = Province.Create("Texas", countryUsa);

            _ctx.Countries.AddRange([countryKz, countryUsa]);
            _ctx.Provinces.AddRange([provinceKz1, provinceKz2, provinceUsa1, provinceUsa2]);
        }


        if (!_ctx.Users.Any())
        {
            var user = User.Create("Admin", "admin@local", "");
            var hash = _passwordHasher.HashPassword(user, "1qaz!QAZ");
            user.SetPassword(hash);

            _ctx.Users.Add(user);
        }

        _ctx.SaveChanges();
    }
}
