using System;
using Domain.Entities.Models;

namespace Domain.Domain.Interfaces.Services
{
    public interface IActivityService : IBaseService<Activity>
    {
        int getTotalActivityByUserId(int userId);
        List<Activity> getActivitiesByUserId(int userId);
    }
}

