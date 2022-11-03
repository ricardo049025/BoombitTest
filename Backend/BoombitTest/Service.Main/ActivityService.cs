using System;
using Domain.Domain.Interfaces;
using Domain.Domain.Interfaces.Services;
using Domain.Entities.Models;

namespace Service.Main
{
    public class ActivityService : BaseService<Activity>, IActivityService
    {
        protected IActivityRepository activityRepository;

        public ActivityService(IActivityRepository activityRepository):base(activityRepository)
        {
            this.activityRepository = activityRepository;
        }

        /// <summary>
        /// Method return all the activities
        /// by the User id.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public int getTotalActivityByUserId(int userId)
        {
            return this.getAll().Count(x => x.UserId == userId);
        }

        public List<Activity> getActivitiesByUserId(int userId)
        {
            return this.activityRepository.GetActivitiesByUserId(userId);
        }
    }
}

