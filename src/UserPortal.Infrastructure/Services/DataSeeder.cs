using System.Xml;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

using UserPortal.Application.Common.Persistance;
using UserPortal.Application.Common.Services;
using UserPortal.Domain.Locations;
using UserPortal.Domain.Users;

namespace UserPortal.Infrastructure.Services;

internal class DataSeederOptions
{
    public bool Enabled { get; set; } = false;
    public string SeedFile { get; set; } = null!;
}

internal class DataSeeder
{
    private readonly ICountriesRepository _countriesRepository;
    private readonly IProvincesRepository _provincesRepository;
    private readonly IUsersRepository _usersRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly bool _seedEnabled;
    private readonly string _seedFile;

    public DataSeeder(
    ICountriesRepository countriesRepository,
    IProvincesRepository provincesRepository,
    IUsersRepository usersRepository,
    IUnitOfWork unitOfWork,
    IPasswordHasher<User> passwordHasher,
    IOptions<DataSeederOptions> options)
    {
        _countriesRepository = countriesRepository;
        _provincesRepository = provincesRepository;
        _usersRepository = usersRepository;
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
        _seedEnabled = options.Value.Enabled;
        _seedFile = options.Value.SeedFile;
    }

    internal void SeedData()
    {
        if (!_seedEnabled)
            return;

        if (!_countriesRepository.GetAll().Any())
        {
            var countries = LoadXmlCountries(_seedFile);

            foreach (var c in countries)
            {
                _countriesRepository.Add(c.Node);
                foreach (var p in c.Children)
                {
                    _provincesRepository.Add(p);
                }
            }
        }

        //if (!_usersRepository.GetAll().Any())
        //{
        //    var user = User.Create("admin@local", "", provinceKz1);
        //    var hash = _passwordHasher.HashPassword(user, "1qaz!QAZ");
        //    user.SetPassword(hash);

        //    _usersRepository.Add(user);
        //}

        _unitOfWork.Save();
    }


    private static IEnumerable<Tree<Country, Province>> LoadXmlCountries(string location)
    {
        var l = new List<Tree<Country, Province>>();
        var xml = new XmlDocument();

        xml.Load(location);

        var nodes = xml.SelectNodes("/countries/country");

        foreach (XmlNode country in nodes)
        {
            var cNode = new Tree<Country, Province>();
            var id = CountryId.Create(country.Attributes?["id"]?.Value ?? "");
            var name = country.Attributes?["name"]?.Value ?? "";
            cNode.Node = Country.Create(id, name);

            foreach (XmlNode provinceNode in country!.SelectNodes("province")!)
            {
                var provinceId = ProvinceId.Create(provinceNode.Attributes?["id"]?.Value ?? "");
                var provinceName = provinceNode.Attributes?["name"]?.Value ?? "";
                cNode.Children.Add(Province.Create(provinceId, provinceName, cNode.Node));
            }

            l.Add(cNode);
        }

        return l;
    }

    private class Tree<T, T2>
        where T : class
    {
        public T Node { get; set; } = null!;
        public List<T2> Children { get; set; } = [];
    }
}
