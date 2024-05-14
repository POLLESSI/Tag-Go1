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
    public class NEvenementController : ControllerBase
    {
        private readonly INEvenementRepository _nEvenementRepository;
        private readonly NEvenementHub _nEvenementHub;
        private readonly Dictionary<string, string> _currentNEvenement = new Dictionary<string, string>();

        public NEvenementController(INEvenementRepository nEvenementRepository, NEvenementHub nEvenementHub)
        {
            _nEvenementRepository = nEvenementRepository;
            _nEvenementHub = nEvenementHub;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_nEvenementRepository.GetAll());
        }
        [HttpGet("{nEvenement_Id}")]
        public IActionResult GetById(int nEvenement_Id)
        {
            return Ok(_nEvenementRepository.GetById(nEvenement_Id));
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(NEvenementRegisterForm nEvenement)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            if (_nEvenementRepository.Create(nEvenement.NEvenementToDal()))
            {
                await _nEvenementHub.RefreshEvenement();
                return Ok();
            }
            return BadRequest("Registration Error");
        }
        [HttpDelete("{nEvenement_Id}")]
        public IActionResult Delete(int nEvenement_Id)
        {
            _nEvenementRepository.Delete(nEvenement_Id);
            return Ok();
        }
        [HttpPut("{nEvenement_Id}")]
        public IActionResult Update(DateTime nEvenementDate, string nEvenementName, string nEvenementDescription, string posLat, string posLong, string positif, int organisateur_Id, int nIcon_Id, int recompense_Id, int bonus_Id, int mediaItem_Id, int nEvenement_Id)
        {
            _nEvenementRepository.Update(nEvenementDate, nEvenementDescription, posLat, posLong, positif, organisateur_Id, nIcon_Id, recompense_Id, bonus_Id, mediaItem_Id, nEvenement_Id);
            return Ok();
        }
        [HttpPost("update")]
        public IActionResult ReceiveEvenementUpdate(Dictionary<string, string> newUpdate)
        {
            foreach (var item in newUpdate)
            {
                _currentNEvenement[item.Key] = item.Value;
            }
            return Ok(_currentNEvenement);
        }
        //[HttpOptions("{evenement_id}")]
        //IActionResult PrefligthRoute(int evenement_Id)
        //{
        //    return NoContent();
        //}
        //[HttpOptions]
        //IActionResult PrefligthRoute()
        //{
        //    return NoContent();
        //}
        //[HttpPut("{evenement_id}")]
        //IActionResult PutTodoItem(int evenement_Id)
        //{
        //    if (evenement_Id < 1)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok(evenement_Id);
        //}
    }
}
