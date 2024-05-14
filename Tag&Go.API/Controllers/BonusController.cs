using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tag_Go.API.Hubs;
using Tag_Go.DAL.Interfaces;
using Tag_Go.API.Dtos.Forms;
using Tag_Go.API.Tools;
using System.Security.Cryptography;

namespace Tag_Go.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BonusController : ControllerBase
    {
        private readonly IBonusRepository _bonusRepository;
        private readonly BonusHub _bonusHub;
        private readonly Dictionary<string, string> _currentBonus = new Dictionary<string, string>();

        public BonusController(IBonusRepository bonusRepository, BonusHub bonusHub)
        {
            _bonusRepository = bonusRepository;
            _bonusHub = bonusHub;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_bonusRepository.GetAll());
        }
        [HttpGet("{bonus_Id}")]
        public IActionResult GetById(int bonus_Id)
        {
            return Ok(_bonusRepository.GetById(bonus_Id));
        }
        [HttpPost]
        public async Task<IActionResult> Create(BonusRegisterForm bonus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (_bonusRepository.Create(bonus.BonusToDal()))
            {
                await _bonusHub.RefreshBonus();
                return Ok();
            }
            return BadRequest("Registration Error");
        }
        [HttpDelete("{bonus_Id}")]
        public IActionResult Delete(int bonus_Id)
        {
            _bonusRepository.Delete(bonus_Id);
            return Ok();
        }
        [HttpPut("bonus_Id")]
        public IActionResult Update(int bonus_Id, string bonusType, string bonusDescription, string application, string granted)
        {
            _bonusRepository.Update(bonus_Id, bonusType, bonusDescription, application, granted);
            return Ok();
        }
        [HttpPost("update")]
        public IActionResult ReceiveBonusUpdate(Dictionary<string, string> newUpdate)
        {
            foreach (var item in newUpdate)
            {
                _currentBonus[item.Key] = item.Value;
            }
            return Ok(_currentBonus);
        }
        //[HttpOptions("{bonus_id}")]
        //IActionResult PrefligthRoute(int bonus_id)
        //{
        //    return NoContent();
        //}
        //[HttpOptions]
        //IActionResult PrefligthRoute()
        //{
        //    return NoContent();
        //}
        //[HttpPut("{bonus_id}")]
        //IActionResult PutTodaItem(int bonus_id)
        //{
        //    if (bonus_id < 1)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok();
        //}
    }
}
