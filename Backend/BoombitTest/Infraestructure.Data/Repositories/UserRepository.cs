using System;
using Domain.Domain.Interfaces;
using Domain.Entities;
using Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data.Repositories
{
    public class UserRepository: BaseRepository<User>, IUserRepository
    {
        protected ApiContext context;

        public UserRepository(ApiContext context) : base(context)
        {
            this.context = context;
        }

        public IEnumerable<User> getUserWithCountryProperties()
        {
            return this.context.Users.Include("Country");
        }

    }
}

