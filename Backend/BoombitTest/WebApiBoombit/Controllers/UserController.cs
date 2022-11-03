using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Domain.Interfaces.Services;
using Domain.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using WebApiBoombit.DTOs.RequestDTO;
using WebApiBoombit.DTOs.ResponseDTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiBoombit.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private IUserService userService;
        private ICountryService countryService;

        public UserController(ILogger<UserController> logger, IUserService userService, ICountryService countryService)
        {
            this._logger = logger;
            this.userService = userService;
            this.countryService = countryService;
        }

        // GET: api/values
        [HttpGet]
        public List<UserResponseDTO> Get()
        {
            return this.userService.getAllWithCountry().Select(x =>
                            new UserResponseDTO { Id = x.Id, Name = x.Name, LastName = x.LastName, Country = x.Country.Name,
                                    Email = x.Email, NeedInformation = x.NeedInformation, PhoneNumber = x.PhoneNumber, birthday = x.Birthday.ToString("yyyy/MM/dd")
                                }).ToList();
        }

        [HttpGet]
        [Route("GetUserById/{id:int}")]
        public UserResponseDTO GetUserById(int id)
        {
            User? user = this.userService.getUserByIdWithCountryProperties(id);

            if (user == null) return new UserResponseDTO();

            return new UserResponseDTO()
            { Id = user.Id, Name = user.Name, LastName = user.LastName, birthday = user.Birthday.ToString("dd/MM/yyyy"),
              Country = user.Country.Code, Email = user.Email, NeedInformation = user.NeedInformation, PhoneNumber = user.PhoneNumber
            };
        }

        // POST api/values
        [HttpPost]
        [Route("ExecuteUser")]
        public UserResponseDTO ExecuteUser([FromBody] UserRequestDTO value)
        {
            var country = this.countryService.getCountryByCode(value.country);
            UserResponseDTO response = new UserResponseDTO();

            User user = new User();
            user.Id = value.id;
            user.Name = value.name;
            user.LastName = value.last;
            user.Birthday = Convert.ToDateTime(value.birthday);
            user.Email = value.email;
            user.NeedInformation = value.information;
            user.PhoneNumber = Convert.ToInt64(value.phone);
            user.Country = country;
            user.CountryId = country.Id ?? 0;
            
            
            response.success = this.userService.AddOrUpdateUser(user, response.xerror);

            return response;
        }


        [HttpDelete]
        [Route("DeleteUser/{id:int}")]
        public bool deleteUser(int id)
        {
            return this.userService.delete(id);
        }

    }
}

