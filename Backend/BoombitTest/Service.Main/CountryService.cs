using System;
using Domain.Domain.Interfaces;
using Domain.Domain.Interfaces.Services;
using Domain.Entities.Models;

namespace Service.Main
{
    public class CountryService : BaseService<Country>, ICountryService
    {
        protected ICountryRepository countryRepository;

        public CountryService(ICountryRepository countryRepository) : base(countryRepository)
        {
            this.countryRepository = countryRepository;
        }

        public IEnumerable<Country> getAllActiveCountries()
        {
            return this.countryRepository.getAll().Where(x => x.Active == true).ToList();
        }

        public Country? getCountryByCode(string code)
        {
            return this.countryRepository.getAll().FirstOrDefault(x => x.Code == code);
        }
    }
}

