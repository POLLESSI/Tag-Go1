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
    public class NIconController : ControllerBase
    {
        private readonly INIconRepository _nIconRepository;
        private readonly NIconHub _nIconHub;
        private readonly Dictionary<string, string> _currentNIcon = new Dictionary<string, string>();

        public NIconController(INIconRepository nIconRepository, NIconHub nIconHub)
        {
            _nIconRepository = nIconRepository;
            _nIconHub = nIconHub;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_nIconRepository.GetAll());
        }
        [HttpGet("{nIcon_Id}")]
        public IActionResult GetById(int nIconId)
        {
            return Ok(_nIconRepository.GetById(nIconId));
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(NIconRegisterForm nIcon)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            if (_nIconRepository.Create(nIcon.NIconToDal()))
            {
                await _nIconHub.RefreshIcon();
                return Ok(nIcon);
            }
            return BadRequest("Registration Error");
        }
        [HttpDelete("{nIcon_Id}")]
        public IActionResult Delete(int nIconId)
        {
            _nIconRepository.Delete(nIconId);
            return Ok();
        }
        [HttpPut("{nIcon_Id}")]
        public IActionResult Update(string nIconName, string nIconDescription, string nIconUrl, int nIconId)
        {
            _nIconRepository.Update(nIconName, nIconDescription, nIconUrl, nIconId);
            return Ok();
        }
        [HttpPost("update")]
        public IActionResult ReceiveIconUpdate(Dictionary<string, string> newUpdate)
        {
            foreach (var item in newUpdate)
            {
                _currentNIcon[item.Key] = item.Value;
            }
            return Ok(_currentNIcon);
        }
    }
}
