using System;
using Domain.Entities.Models;

namespace Domain.Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        IEnumerable<User> getUserWithCountryProperties();
    }
}

