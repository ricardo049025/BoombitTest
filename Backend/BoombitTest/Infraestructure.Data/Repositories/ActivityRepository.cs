using System;
using Domain.Domain.Interfaces;
using Domain.Entities;
using Domain.Entities.Models;

namespace Infraestructure.Data.Repositories
{
    public class ActivityRepository : BaseRepository<Activity>, IActivityRepository
    {
        protected ApiContext context;

        public ActivityRepository(ApiContext context) : base(context)
        {
            this.context = context;
        }
    }
}

