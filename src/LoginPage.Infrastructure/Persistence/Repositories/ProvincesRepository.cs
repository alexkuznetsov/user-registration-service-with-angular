﻿using LoginPage.Application.Common.Persistance;
using LoginPage.Domain.Locations;

using Microsoft.EntityFrameworkCore;

namespace LoginPage.Infrastructure.Persistence.Repositories;

internal class ProvincesRepository : IProvincesRepository
{
    private readonly LoginPageDbContext _context;

    public ProvincesRepository(LoginPageDbContext context)
    {
        _context = context;
    }

    public Task<Province?> FindAsync(ProvinceId id, CancellationToken cancellationToken = default)
    {
        return _context.Provinces.Where(p => p.Id == id)
            .SingleOrDefaultAsync(cancellationToken);
    }

    public IQueryable<Province> GetAll()
    {
        return _context.Provinces
            .Include(x => x.Country);
    }

    public IQueryable<Province> GetAllByCountry(CountryId countryId)
    {
        return _context.Provinces
           .Include(x => x.Country)
           .Where(x => x.Country.Id == countryId);
    }
}