using System;
using Domain.Domain.Interfaces;
using Domain.Domain.Interfaces.Services;
using Domain.Entities;
using Infraestructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Service.Main;

namespace UnitTest
{
    public class BoombitTests
    {
        #region Variables_To_Use
        private DbContextOptions<ApiContext> options = new DbContextOptionsBuilder<ApiContext>().UseInMemoryDatabase(databaseName: "dbBoombit").Options;
        private ApiContext apiContext;

        private IActivityRepository activityRepository;
        private ICountryRepository countryRepository;
        private IUserRepository userRepository;

        private IActivityService activityService;
        private ICountryService countryService;
        private IUserService userService;

        #endregion

        public BoombitTests()
        {
            apiContext = new ApiContext(options);
            activityRepository = new ActivityRepository(this.apiContext);
            countryRepository = new CountryRepository(this.apiContext);
            userRepository = new UserRepository(this.apiContext);

            activityService = new ActivityService(activityRepository);
            countryService = new CountryService(countryRepository);
            userService = new UserService(userRepository, activityRepository, countryRepository);

        }

        #region PrincipalTest

        [Test]
        public void ExecuteProcessUser()
        {
            
        }

        #endregion


    }
}

