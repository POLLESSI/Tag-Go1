using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tag_Go.API.Hubs;
using Tag_Go.DAL.Interfaces;
using Tag_Go.API.Dtos.Forms;
using Tag_Go.API.Tools;
using System.Security.Cryptography;
//using System.Reflection.Metadata.Ecma335;

namespace Tag_Go.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IconController : ControllerBase
    {
        private readonly IIconRepository _iconRepository;
        private readonly IconHub _iconHub;
        private readonly Dictionary<string, string> _currentIcon = new Dictionary<string, string>();

        public IconController(IIconRepository iconRepository, IconHub iconHub)
        {
            _iconRepository = iconRepository;
            _iconHub = iconHub;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_iconRepository.GetAll());
        }
        [HttpGet("{icon_id}")]
        public IActionResult GetById(int iconId)
        {
            return Ok(_iconRepository.GetById(iconId));
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(IconRegisterForm icon)
        {
            if (!ModelState.IsValid) 
                return BadRequest();
            if (_iconRepository.Create(icon.IconToDal()))
            {
                await _iconHub.RefreshIcon();
                return Ok(icon);
            }
            return BadRequest("Registration Error");
        }
        [HttpDelete("{icon_id}")]
        public IActionResult Delete(int iconId)
        {
            _iconRepository.Delete(iconId);
            return Ok();
        }
        [HttpPut("{icon_id}")]
        public IActionResult Update(int iconId, string iconName, string iconDescription, string iconUrl)
        {
            _iconRepository.Update(iconId, iconName, iconDescription, iconUrl);
            return Ok();
        }
        [HttpPost("update")]
        public IActionResult ReceiveIconUpdate(Dictionary<string, string> newUpdate)
        {
            foreach (var item in newUpdate)
            {
                _currentIcon[item.Key] = item.Value;
            }
            return Ok(_currentIcon);
        }
    }
}
