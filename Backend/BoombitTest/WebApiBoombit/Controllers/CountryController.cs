using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using WebApiBoombit.DTOs.ResponseDTO;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiBoombit.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private ICountryService countryService;


        public CountryController(ILogger<UserController> logger, ICountryService countryService)
        {
            this._logger = logger;
            this.countryService = countryService;
        }

        // GET: /<controller>/
        public List<CountryResponseDTO> Index()
        {
            return this.countryService.getAllActiveCountries().Select(x => new CountryResponseDTO { code = x.Code, name = x.Name}).ToList();
        }
    }
}

