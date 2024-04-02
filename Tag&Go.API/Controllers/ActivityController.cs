using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tag_Go.API.Hubs;
using Tag_Go.DAL.Interfaces;
using Tag_Go.API.Dtos.Forms;
using Tag_Go.API.Tools;
using System.Security.Cryptography;
using System.Reflection.Metadata.Ecma335;

namespace Tag_Go.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityRepository _activityRepository;
        private readonly ActivityHub _activityHub;
        private readonly Dictionary<string, string> _currentActivity = new Dictionary<string, string>();

        public ActivityController(IActivityRepository activityRepository, ActivityHub activityHub)
        {
            _activityRepository = activityRepository;
            _activityHub = activityHub;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_activityRepository.GetAll());
        }
        [HttpGet("{activity_id}")]
        public IActionResult GetById(int activity_Id)
        {
            return Ok(_activityRepository.GetById(activity_Id));
        }
        [HttpPost]
        public async Task<IActionResult> Create(ActivityRegisterForm activity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (_activityRepository.Create(activity.ActivityToDal()))
            {
                await _activityHub.RefreshActivity();
                return Ok();
            }
            return BadRequest("Registration Error");
        }
        [HttpDelete("{activity_id}")]
        public IActionResult Delete(int activity_Id)
        {
            _activityRepository.Delete(activity_Id);
            return Ok();
        }
        [HttpPut("{ectivity_id}")]
        public IActionResult Update(int activity_Id, string activityName, string activityAddress, string activityDescription, string ComplementareInformation, string posLat, string posLong, int organisateur_Id)
        {
            _activityRepository.Update(activity_Id, activityName, activityAddress, activityDescription, ComplementareInformation, posLat, posLong, organisateur_Id);
            return Ok();
        }
        [HttpPost("update")]
        public IActionResult ReceiveActivityUpdate(Dictionary<string, string> newUpdate)
        {
            foreach (var item in newUpdate)
            {
                _currentActivity[item.Key] = item.Value;
            }
            return Ok(_currentActivity);
        }
        //[HttpOptions("{activity_id}")]
        //IActionResult PrefligthRoute(int activity_Id) 
        //{
        //    return NoContent();
        //}
        //// OPTIONS: api/Activity
        //[HttpOptions]
        //IActionResult PrefligthRoute()
        //{
        //    return NoContent();
        //}
        //[HttpPut("{activity_id}")]
        //IActionResult PutTodoItem(int activity_Id)
        //{
        //    if (activity_Id < 1)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok(activity_Id);
        //}
    }
}
