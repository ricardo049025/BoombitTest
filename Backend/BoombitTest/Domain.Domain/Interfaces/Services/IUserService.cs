using System;
using Domain.Entities.Models;

namespace Domain.Domain.Interfaces.Services
{
    public interface IUserService : IBaseService<User>
    {
        IEnumerable<User> getAllWithCountry();
        bool AddOrUpdateUser(User user, string? xmessage = "");
    }
}

