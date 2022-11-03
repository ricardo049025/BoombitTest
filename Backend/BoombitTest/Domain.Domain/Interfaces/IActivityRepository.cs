using System;
using Domain.Entities.Models;

namespace Domain.Domain.Interfaces
{
    public interface IActivityRepository : IBaseRepository<Activity>
    {
        List<Activity> GetActivitiesByUserId(int id);
    }
}

