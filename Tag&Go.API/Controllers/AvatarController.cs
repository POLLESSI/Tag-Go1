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
    public class AvatarController : ControllerBase
    {
        private readonly IAvatarRepository _avatarRepository;
        private readonly AvatarHub _avatarHub;
        private readonly Dictionary<string, string> _currentAvatar = new Dictionary<string, string>();

        public AvatarController(IAvatarRepository avatarRepository, AvatarHub avatarHub)
        {
            _avatarRepository = avatarRepository;
            _avatarHub = avatarHub;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_avatarRepository.GetAll());
        }
        [HttpGet("{avatar_id}")]
        public IActionResult GetById(int avatar_Id)
        {
            return Ok(_avatarRepository.GetById(avatar_Id));
        }
        [HttpPost]
        public async Task<IActionResult> Create(AvatarRegisterForm avatar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (_avatarRepository.Create(avatar.AvatarToDal()))
            {
                await _avatarHub.RefreshAvatar();
                return Ok();
            }
            return BadRequest("Registration Error");
        }
        [HttpDelete("{avatar_id}")]
        public IActionResult Delete(int avatar_Id)
        {
            _avatarRepository.Delete(avatar_Id);
            return Ok();
        }
        [HttpPut("{avatar_id}")]
        public IActionResult Update(int avatar_Id, string avatarName, string avatarUrl, string description, Guid NUser_Id)
        {
            _avatarRepository.Update(avatar_Id, avatarName, avatarUrl, description, NUser_Id);
            return Ok();
        }
        [HttpPost("update")]
        public IActionResult ReceiveAvatarUpdate(Dictionary<string, string> newUpdate)
        {
            foreach (var item in newUpdate)
            {
                _currentAvatar[item.Key] = item.Value;
            }
            return Ok(_currentAvatar);
        }
        //[HttpOptions("{avatar_id}")]
        //IActionResult PrefligthRoute(int avatar_Id)
        //{
        //    return NoContent();
        //}
        //[HttpOptions]
        //IActionResult PrefligthRoute()
        //{
        //    return NoContent();
        //}
        //[HttpPut("{avatar_id}")]
        //IActionResult PutTodoItem(int avatar_Id)
        //{
        //    if (avatar_Id < 1)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok(avatar_Id);
        //}
    }
}
