using System;
using Domain.Entities.Models;

namespace Domain.Domain.Interfaces.Services
{
    public interface ICountryService : IBaseService<Country>
    {
        IEnumerable<Country> getAllActiveCountries();
        Country? getCountryByCode(string code);
    }
}

