using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
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

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            this._logger = logger;
            this.userService = userService;
        }

        // GET: api/values
        [HttpGet]
        public List<UserResponseDTO> Get()
        {
            return this.userService.getAllWithCountry().Select(x =>
                            new UserResponseDTO { Id = x.Id, Name = x.Name, LastName = x.LastName, Country = x.Country.Name,
                                    Email = x.Email, NeedInformation = x.NeedInformation, PhoneNumber = x.PhoneNumber
                                }).ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


    }
}

