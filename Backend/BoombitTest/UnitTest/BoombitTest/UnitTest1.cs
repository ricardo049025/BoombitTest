using System;
using Domain.Domain.Interfaces;
using Domain.Domain.Interfaces.Services;
using Domain.Entities;
using Domain.Entities.Models;
using Infraestructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Service.Main;

namespace BoombitTest;

public class Tests
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

    [SetUp]
    public void Setup()
    {
        apiContext = new ApiContext(options);
        activityRepository = new ActivityRepository(this.apiContext);
        countryRepository = new CountryRepository(this.apiContext);
        userRepository = new UserRepository(this.apiContext);

        activityService = new ActivityService(activityRepository);
        countryService = new CountryService(countryRepository);
        userService = new UserService(userRepository, activityRepository, countryRepository);
    }

    [Test]
    public void ExecuteProcessUser()
    {
        string message = string.Empty;

        Country country = new Country();
        country.Code = "NIC";
        country.Name = "Nicaragua";
        country.Active = true;

        Assert.AreEqual(true, countryService.add(country));

        User user = new User();
        user.Name = "Ricardo";
        user.LastName = "Martinez";
        user.Birthday = new DateTime(1996,01,18);
        user.Country = country;
        user.Email = "ricardom0490@gmail.com";
        user.PhoneNumber = 85021379;
        user.Country = country;
        user.NeedInformation = true;

        Assert.AreEqual(true, userService.AddOrUpdateUser(user));
        Assert.AreNotEqual(0,activityService.getTotalActivityByUserId(user.Id));
    }
}
