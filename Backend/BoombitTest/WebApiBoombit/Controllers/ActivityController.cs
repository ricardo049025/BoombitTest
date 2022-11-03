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
    public class ActivityController : Controller
    {

        private readonly ILogger<UserController> _logger;
        private IActivityService activityService;

        public ActivityController(ILogger<UserController> logger, IActivityService activityService)
        {
            this._logger = logger;
            this.activityService = activityService;
        }

        // GET: /<controller>/
        public List<ActivityResponseDTO> Index()
        {
            return this.activityService.getAll().Select(x => new ActivityResponseDTO { id = x.Id, fullName = x.UserId.ToString() ,createdDate = x.CreatedDay.ToString("yyyy/MM/dd/HH:mm:ss"), description = x.ActivityDescription }).ToList();
        }

        [HttpGet]
        [Route("getActivitiesByUserId/{id:int}")]
        public List<ActivityResponseDTO> getActivitiesByUserId(int id)
        {
            return this.activityService.getActivitiesByUserId(id).OrderByDescending(y => y.CreatedDay).Select(x => new ActivityResponseDTO {id= x.Id, createdDate = x.CreatedDay.ToString("yyyy/MM/dd/HH:mm:ss"), description = x.ActivityDescription, fullName = $"{x.User.Name} {x.User.LastName}" }).ToList();
        }


    }
}

