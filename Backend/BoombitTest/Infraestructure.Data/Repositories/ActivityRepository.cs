using System;
using Domain.Domain.Interfaces;
using Domain.Entities;
using Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data.Repositories
{
    public class ActivityRepository : BaseRepository<Activity>, IActivityRepository
    {
        protected ApiContext context;

        public ActivityRepository(ApiContext context) : base(context)
        {
            this.context = context;
        }

        public List<Activity> GetActivitiesByUserId(int id)
        {
            return this.context.Activities.Where(x => x.UserId == id).Include(y => y.User).ToList();
        }
    }
}

