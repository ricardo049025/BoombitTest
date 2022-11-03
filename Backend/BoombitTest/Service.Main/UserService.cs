using System;
using System.Text;
using Domain.Domain.Interfaces;
using Domain.Domain.Interfaces.Services;
using Domain.Entities.Models;

namespace Service.Main
{
    /// <summary>
    /// Service logic, in this class we manage the logical
    /// about the User
    /// </summary>
    public class UserService : BaseService<User>, IUserService
    {
        protected IUserRepository userRepository;
        protected IActivityRepository activityRepository;
        protected ICountryRepository countryRepository;

        public UserService(IUserRepository userRepository, IActivityRepository activityRepository, ICountryRepository countryRepository) :base(userRepository)
        {
            this.userRepository = userRepository;
            this.activityRepository = activityRepository;
            this.countryRepository = countryRepository;
        }

        public IEnumerable<User> getAllWithCountry()
        {
            return this.userRepository.getUserWithCountryProperties();
        }

        /// <summary>
        /// This method we add a new user and at the same time
        /// we registered his activity
        /// </summary>
        /// <param name="user"></param>
        /// <param name="xmessage"></param>
        /// <returns></returns>
        public bool AddOrUpdateUser(User user, string? xmessage)
        {
            string action = (user.Id == null || user.Id == 0 ? "CREATE" : "UPDATE");
            StringBuilder messageValidation = new StringBuilder();
            Activity activity = new Activity();

            if (String.IsNullOrEmpty(user.Name)) messageValidation.AppendLine("The Name is required");
            if (String.IsNullOrEmpty(user.LastName)) messageValidation.AppendLine("The LastName is required");
            if (user.Birthday == null) messageValidation.AppendLine("The Birthday is required");
            if (countryRepository.getById(user.CountryId) == null) messageValidation.AppendLine("The country code is not valid");

            xmessage = messageValidation.ToString();
            if (xmessage.Length > 0) return false;

            switch (action)
            {
                case "CREATE":
                    if (!this.userRepository.add(user))
                    {
                        xmessage += "Error saving user";
                        return false;
                    }
                    else
                    {
                        activity.CreatedDay = DateTime.Now;
                        activity.UserId = user.Id;
                        activity.ActivityDescription = action;
                        if (!this.activityRepository.add(activity))
                        {
                            xmessage += "Error saving activity";
                            return false;
                        }
                    }
                    break;

                case "UPDATE":

                    if (!this.userRepository.update(user))
                    {
                        xmessage += "Error updating user";
                        return false;
                    }
                    else
                    {
                        activity.CreatedDay = DateTime.Now;
                        activity.UserId = user.Id;
                        activity.ActivityDescription = action;
                        if (!this.activityRepository.add(activity))
                        {
                            xmessage += "Error saving activity in update user";
                            return false;
                        }
                    }

                    break;

                default:
                    break;
            }

            return true;
        }
       
    }
}
