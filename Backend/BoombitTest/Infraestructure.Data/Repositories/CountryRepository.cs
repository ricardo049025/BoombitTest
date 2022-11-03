using System;
using Domain.Domain.Interfaces;
using Domain.Entities;
using Domain.Entities.Models;

namespace Infraestructure.Data.Repositories
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        protected ApiContext context;

        public CountryRepository(ApiContext context) : base(context)
        {
            this.context = context;
        }
    }
}

