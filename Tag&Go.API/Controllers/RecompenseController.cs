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
    public class RecompenseController : ControllerBase
    {
        private readonly IRecompenseRepository _recompenseRepository;
        private readonly RecompenseHub _recompenseHub;
        private readonly Dictionary<string, string> _currentRecompense = new Dictionary<string, string>();

        public RecompenseController(IRecompenseRepository recompenseRepository, RecompenseHub recompenseHub)
        {
            _recompenseRepository = recompenseRepository;
            _recompenseHub = recompenseHub;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_recompenseRepository.GetAll());
        }
        [HttpGet("{recompense_Id}")]
        public ActionResult GetById(int recompense_Id)
        {
            return Ok(_recompenseRepository.GetById(recompense_Id));
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(RecompenseRegisterForm recompense)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            if (_recompenseRepository.Create(recompense.RecompenseToDal()))
            {
                await _recompenseHub.RefreshRecompense();
                return Ok(recompense);
            }
            return BadRequest("Registration Error");
        }
        [HttpPut("{recompense_Id}")]
        public IActionResult Update(string definition, string point, string implication, string granted, int recompense_Id)
        {
            _recompenseRepository.Update(definition, point, implication, granted, recompense_Id);
            return Ok();
        }
        [HttpPost("update")]
        public IActionResult ReceiveRecompenseUpdate(Dictionary<string, string> newUpdate)
        {
            foreach (var item in newUpdate)
            {
                _currentRecompense[item.Key] = item.Value;
            }
            return Ok(_currentRecompense);
        }
        //[HttpOptions("{recompense_id}")]
        //IActionResult PrefligthRoute(int recompense_Id)
        //{
        //    return NoContent();
        //}
        //// OPTIONS: api/recompense
        //[HttpOptions]
        //IActionResult PrefligthRoute()
        //{
        //    return NoContent();
        //}
        //[HttpPut("recompense_id")]
        //IActionResult PutTodoItem(int recompense_Id)
        //{
        //    if (recompense_Id < 1)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok(recompense_Id);
        //}
    }
}
